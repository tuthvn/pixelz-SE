import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface Order {
  orderId: string;
  orderName: string;
  orderStatus: string;
  createdAt: string;
  updatedAt: string;
}

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent implements OnInit {
  orders: Order[] = [];
  searchName: string = '';

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.fetchOrders();
  }

  fetchOrders(): void {
    this.http.get<Order[]>('/api/orders', { params: { name: this.searchName } })
      .subscribe(data => this.orders = data, error => console.error('Error fetching orders:', error));
  }

  handleCheckout(orderId: string): void {
    this.http.post(`/api/orders/${orderId}/checkout`, {})
      .subscribe(data => {
        console.log('Order checked out:', data);
        this.fetchOrders();
      }, error => console.error('Error checking out order:', error));
  }
}
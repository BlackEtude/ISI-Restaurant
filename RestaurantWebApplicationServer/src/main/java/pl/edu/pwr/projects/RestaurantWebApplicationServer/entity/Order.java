package pl.edu.pwr.projects.RestaurantWebApplicationServer.entity;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;

@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
@Entity
@Table(name = "ORDERS")
public class Order {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private long id;

    private CustomerData customerData;

    @Column(name = "total_price")
    private double totalPrice;

    @Column(name = "delivery_type")
    private String deliveryType;

    @Column(name = "status")
    private String status;
}

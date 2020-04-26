package pl.edu.pwr.projects.RestaurantWebApplicationServer.entity;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.DeliveryType;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.OrderStatus;

import javax.persistence.*;
import java.util.Set;

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
    private DeliveryType deliveryType;

    @Column(name = "status")
    private OrderStatus status;

    @ManyToMany(cascade = CascadeType.ALL)
    private Set<OrderItem> orderItems;

    @OneToOne
    @JoinColumn(name = "delivery_point_id")
    private DeliveryPoint deliveryPoint;
}

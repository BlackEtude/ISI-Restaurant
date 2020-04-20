package pl.edu.pwr.projects.RestaurantWebApplicationServer.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.entity.OrderItem;

public interface OrderItemRepository extends JpaRepository<OrderItem, Long> {
}

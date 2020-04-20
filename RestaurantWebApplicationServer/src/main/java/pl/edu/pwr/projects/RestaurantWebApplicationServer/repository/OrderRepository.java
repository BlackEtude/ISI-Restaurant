package pl.edu.pwr.projects.RestaurantWebApplicationServer.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.entity.Order;

@Repository
public interface OrderRepository extends JpaRepository<Order, Long> {
}

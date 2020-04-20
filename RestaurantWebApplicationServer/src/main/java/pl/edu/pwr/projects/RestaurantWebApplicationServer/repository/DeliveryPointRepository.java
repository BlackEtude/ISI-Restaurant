package pl.edu.pwr.projects.RestaurantWebApplicationServer.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.entity.DeliveryPoint;

import java.util.UUID;

@Repository
public interface DeliveryPointRepository extends JpaRepository<DeliveryPoint, Long> {
}

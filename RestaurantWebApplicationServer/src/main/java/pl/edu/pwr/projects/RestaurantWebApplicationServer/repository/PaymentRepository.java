package pl.edu.pwr.projects.RestaurantWebApplicationServer.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.entity.Payment;

import java.util.UUID;

@Repository
public interface PaymentRepository extends JpaRepository<Payment, Long> {
}

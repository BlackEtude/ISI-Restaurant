package pl.edu.pwr.projects.RestaurantWebApplicationServer.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.entity.Product;

@Repository
public interface ProductRepository extends JpaRepository<Product, Long> {
}

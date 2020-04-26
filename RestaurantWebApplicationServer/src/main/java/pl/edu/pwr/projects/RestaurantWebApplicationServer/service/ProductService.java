package pl.edu.pwr.projects.RestaurantWebApplicationServer.service;

import org.springframework.stereotype.Service;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.entity.Product;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.exception.ProductNotFoundException;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.repository.ProductRepository;

import java.util.List;

@Service
public class ProductService {

    private ProductRepository productRepository;

    public ProductService(ProductRepository productRepository) {
        this.productRepository = productRepository;
    }

    public List<Product> getAllProducts() {
        return productRepository.findAll();
    }

    public Product getProductById(Long id) {
        return productRepository.findById(id).orElseThrow(ProductNotFoundException::new);
    }
}

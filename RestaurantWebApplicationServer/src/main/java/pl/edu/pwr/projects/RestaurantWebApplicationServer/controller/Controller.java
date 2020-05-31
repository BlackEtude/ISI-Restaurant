package pl.edu.pwr.projects.RestaurantWebApplicationServer.controller;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.entity.*;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.payu.service.PayUOrderService;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.service.DeliveryPointService;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.service.OrderService;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.service.ProductService;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.service.ToppingService;

import java.util.List;

@RestController
public class Controller {

    private DeliveryPointService deliveryPointService;
    private OrderService orderService;
    private ProductService productService;
    private ToppingService toppingService;
    private PayUOrderService payUOrderService;

    public Controller(DeliveryPointService deliveryPointService, OrderService orderService,
                      ProductService productService, ToppingService toppingService,
                      PayUOrderService payUOrderService) {
        this.deliveryPointService = deliveryPointService;
        this.orderService = orderService;
        this.productService = productService;
        this.toppingService = toppingService;
        this.payUOrderService = payUOrderService;
    }

    @GetMapping("/product")
    List<Product> getAllProducts() {
        return productService.getAllProducts();
    }

    @GetMapping("/product/{id}")
    Product getProductById(@PathVariable("id") Long id) {
        return productService.getProductById(id);
    }

    @PostMapping("/order")
    ResponseEntity createNewOrder(@RequestBody Order order) {
        Order newOrder = orderService.createNewOrder(order);
        return payUOrderService.createPayUOrder(newOrder);
    }

    @GetMapping("/order/{id}")
    Order getOrderById(@PathVariable Long id) {
        return orderService.getOrderById(id);
    }

    @GetMapping("/deliverypoint")
    List<DeliveryPoint> getAllDeliveryPoints() {
        return deliveryPointService.getAllToppings();
    }

    @GetMapping("/topping")
    List<Topping> getAllToppings() {
        return toppingService.getAllToppings();
    }
}

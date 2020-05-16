package pl.edu.pwr.projects.RestaurantWebApplicationServer.service;

import org.springframework.http.HttpStatus;
import org.springframework.stereotype.Service;
import org.springframework.web.bind.annotation.ResponseStatus;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.DeliveryType;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.entity.DeliveryPoint;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.entity.Order;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.entity.Product;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.entity.Topping;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.exception.OrderNotFoundException;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.repository.OrderRepository;

import javax.xml.crypto.Data;
import java.time.LocalDateTime;
import java.util.HashSet;
import java.util.Set;

@Service
public class OrderService {

    private OrderRepository orderRepository;
    private ProductService productService;
    private ToppingService toppingService;
    private DeliveryPointService deliveryPointService;

    public OrderService(OrderRepository orderRepository, ProductService productService,
                        ToppingService toppingService, DeliveryPointService deliveryPointService) {
        this.orderRepository = orderRepository;
        this.productService = productService;
        this.toppingService = toppingService;
        this.deliveryPointService = deliveryPointService;
    }

    public Order getOrderById(Long id) {
        return orderRepository.findById(id).orElseThrow(OrderNotFoundException::new);
    }

    public Order createNewOrder(Order order) {
        order.getOrderItems().forEach(orderItem -> {
            long productId = orderItem.getProduct().getId();
            Product product = productService.getProductById(productId);
            orderItem.setProduct(product);

            Set<Topping> toppings = new HashSet<>();
            for (Topping topping : orderItem.getToppings()) {
                long toppingId = topping.getId();
                Topping toppingObject = toppingService.getToppingById(toppingId);
                toppings.add(toppingObject);
            }
            orderItem.setToppings(toppings);
        });

        order.setDeliveryType(order.getDeliveryType());

        if(order.getDeliveryType().equals(DeliveryType.PICKUP)) {
            long deliveryPointId = order.getDeliveryPoint().getId();
            DeliveryPoint deliveryPoint = deliveryPointService.getDeliveryPointById(deliveryPointId);
            order.setDeliveryPoint(deliveryPoint);
        }

        order.setDate(LocalDateTime.now());

        return orderRepository.save(order);
    }
}

package pl.edu.pwr.projects.RestaurantWebApplicationServer;

import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.entity.*;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.repository.*;

import java.util.stream.Collectors;
import java.util.stream.Stream;

@Component
public class MockedDataLoader implements CommandLineRunner {

    private OrderRepository orderRepository;
    private OrderItemRepository orderItemRepository;
    private PaymentRepository paymentRepository;
    private ProductRepository productRepository;
    private ToppingRepository toppingRepository;
    private DeliveryPointRepository deliveryPointRepository;

    public MockedDataLoader(OrderRepository orderRepository,
                            OrderItemRepository orderItemRepository,
                            PaymentRepository paymentRepository,
                            ProductRepository productRepository,
                            ToppingRepository toppingRepository,
                            DeliveryPointRepository deliveryPointRepository) {
        this.orderRepository = orderRepository;
        this.orderItemRepository = orderItemRepository;
        this.paymentRepository = paymentRepository;
        this.productRepository = productRepository;
        this.toppingRepository = toppingRepository;
        this.deliveryPointRepository = deliveryPointRepository;
    }


    @Override
    public void run(String... args) throws Exception {

        Address address = Address.builder()
                .street("ul. Gazowa 76/1")
                .postalCode("50-513")
                .city("Wrocław")
                .country("Polska")
                .build();

        CustomerData customerData = CustomerData.builder()
                .firstName("Izabela")
                .lastName("Wójciak")
                .phoneNumber("534731661")
                .address(address)
                .emailAddress("izabelawojciak96@gmail.com")
                .build();

        Product product = productRepository.findById(1l).get();

        DeliveryPoint deliveryPoint = deliveryPointRepository.findById(1l).get();

        Topping topping1 = toppingRepository.findById(1l).get();
        Topping topping2 = toppingRepository.findById(2l).get();
        Topping topping3 = toppingRepository.findById(3l).get();

        OrderItem orderItem = OrderItem.builder()
                .product(product)
                .productSize(ProductSize.MEDIUM)
                .toppings(Stream.of(topping1, topping2, topping3).collect(Collectors.toSet()))
                .build();

        OrderItem orderItem2 = OrderItem.builder()
                .product(product)
                .productSize(ProductSize.SMALL)
                .toppings(Stream.of(topping1, topping3).collect(Collectors.toSet()))
                .build();

        Order order = Order.builder()
                .customerData(customerData)
                .deliveryType(DeliveryType.PICKUP)
                .status(OrderStatus.CREATED)
                .totalPrice(26)
                .orderItems(Stream.of(orderItem, orderItem2).collect(Collectors.toSet()))
                .deliveryPoint(deliveryPoint)
                .build();

        Payment payment = Payment.builder()
                .order(order)
                .status(PaymentStatus.COMPLETED)
                .build();

        orderRepository.save(order);
        orderItemRepository.save(orderItem);
        orderItemRepository.save(orderItem2);
        deliveryPointRepository.save(deliveryPoint);
        paymentRepository.save(payment);
    }
}

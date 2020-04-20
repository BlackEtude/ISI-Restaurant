package pl.edu.pwr.projects.RestaurantWebApplicationServer;

import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.entity.*;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.repository.OrderItemRepository;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.repository.OrderRepository;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.repository.PaymentRepository;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.repository.ProductRepository;

@Component
public class MockedDataLoader implements CommandLineRunner {

    private OrderRepository orderRepository;
    private OrderItemRepository orderItemRepository;
    private PaymentRepository paymentRepository;
    private ProductRepository productRepository;

    public MockedDataLoader(OrderRepository orderRepository,
                            OrderItemRepository orderItemRepository,
                            PaymentRepository paymentRepository,
                            ProductRepository productRepository) {
        this.orderRepository = orderRepository;
        this.orderItemRepository = orderItemRepository;
        this.paymentRepository = paymentRepository;
        this.productRepository = productRepository;
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

        Order order = Order.builder()
                .customerData(customerData)
                .deliveryType("odbiór własny")
                .status("opłacone")
                .totalPrice(26)
                .build();

        OrderItem orderItem = OrderItem.builder()
                .order(order)
                .product(product)
                .count(1)
                .build();

        Payment payment = Payment.builder()
                .order(order)
                .status("COMPLETED")
                .build();

        orderItemRepository.save(orderItem);
        orderRepository.save(order);
        paymentRepository.save(payment);
    }
}

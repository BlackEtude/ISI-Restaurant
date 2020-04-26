package pl.edu.pwr.projects.RestaurantWebApplicationServer.service;

import org.springframework.stereotype.Service;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.entity.DeliveryPoint;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.exception.DeliveryPointNotFound;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.repository.DeliveryPointRepository;

import java.util.List;

@Service
public class DeliveryPointService {

    private DeliveryPointRepository deliveryPointRepository;

    public DeliveryPointService(DeliveryPointRepository deliveryPointRepository) {
        this.deliveryPointRepository = deliveryPointRepository;
    }

    public List<DeliveryPoint> getAllToppings() {
        return deliveryPointRepository.findAll();
    }

    public DeliveryPoint getDeliveryPointById(Long id) {
        return deliveryPointRepository.findById(id).orElseThrow(DeliveryPointNotFound::new);
    }
}

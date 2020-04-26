package pl.edu.pwr.projects.RestaurantWebApplicationServer.service;

import org.springframework.stereotype.Service;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.entity.Topping;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.exception.ToppingNotFoundException;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.repository.ToppingRepository;

import java.util.List;

@Service
public class ToppingService {

    private ToppingRepository toppingRepository;

    public ToppingService(ToppingRepository toppingRepository) {
        this.toppingRepository = toppingRepository;
    }

    public List<Topping> getAllToppings() {
        return toppingRepository.findAll();
    }

    public Topping getToppingById(Long id) {
        return toppingRepository.findById(id).orElseThrow(ToppingNotFoundException::new);
    }
}

using Application;
using Application.DTOs;
using Domain;
using Application.Interfaces;
using Application.Validators;
using AutoMapper;
using FluentValidation;
using Moq;

namespace PizzaTest;

public class UnitTest1
{
    private IPizzaRepository _pizzaRepository;
    private IMapper _mapper;
    private PostPizzaValidator _postValidator;
    private PizzaValidator _pizzaValidator;

    public UnitTest1()
    {
        
    }
    [Fact]
    public void GetAllPizzas()
    {
        // Arrange

        var Pizza1 = new Pizza() { Name = "Napoli", AlmPrice = 50, Fam40x40Price = 110, Fam50x50Price = 160, AlmGlutenfriPrice = 75, Topping = "Ost, TomatSauce, Peperoni, Cocktailpølser, Dressing" };
        var Pizza2 = new Pizza() { Name = "Magharita", AlmPrice = 45, Fam40x40Price = 115,Fam50x50Price = 180, AlmGlutenfriPrice = 80, Topping = "Ost, TomatSauce" };
        var Pizza3 = new Pizza() { Name = "Kebab", AlmPrice = 60,Fam40x40Price = 120, Fam50x50Price = 190,AlmGlutenfriPrice = 85,Topping = "Ost, TomatSauce, Salat, Kebab, Dressing" };
        List<Pizza> fakeRepo = new List<Pizza>() { Pizza1, Pizza2, Pizza3 };

        Mock<IPizzaRepository> mockRepository = new Mock<IPizzaRepository>();
        mockRepository.Setup(r => r.GetAllPizzas()).Returns(fakeRepo);

        IPizzaService service = new PizzaService(mockRepository.Object, _mapper, _postValidator, _pizzaValidator);
        
        // Act
        List<Pizza> result = service.GetAllPizzas();

        // Assert
        Assert.True(result.Count == 3);
        Assert.Contains(Pizza1,result);
        Assert.Contains(Pizza2,result);
        Assert.Contains(Pizza3,result);
  
        mockRepository.Verify(r => r.GetAllPizzas(), Times.Once);
    
    } 
}
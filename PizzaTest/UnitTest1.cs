using Application;
using Application.DTOs;
using Domain;
using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using Moq;

namespace PizzaTest;

public class UnitTest1
{
    private IPizzaRepository _pizzaRepository;
    private IMapper _mapper;
    private IValidator<PizzaDTOs> _postValidator;
    private IValidator<Pizza> _pizzaValidator;

    public UnitTest1()
    {
        _mapper = 
    }
    [Fact]
    public void GetAllPizzas()
    {
        // Arrange

        var Pizza1 = new Pizza() { Name = "Napoli", Price = 50, Topping = "Ost, TomatSauce, Peperoni, Cocktailpølser, Dressing" };
        var Pizza2 = new Pizza() { Name = "Magharita", Price = 45, Topping = "Ost, TomatSauce" };
        var Pizza3 = new Pizza() { Name = "Kebab", Price = 60, Topping = "Ost, TomatSauce, Salat, Kebab, Dressing" };
        List<Pizza> fakeRepo = new List<Pizza>() { Pizza1, Pizza2, Pizza3 };

        Mock<IPizzaRepository> mockRepository = new Mock<IPizzaRepository>();
        mockRepository.Setup(r => r.GetAllPizzas()).Returns(fakeRepo);

        IPizzaService service = new PizzaService(mockRepository.Object,);
        
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
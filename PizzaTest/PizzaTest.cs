using Application;
using Application.DTOs;
using Domain;
using Application.Interfaces;
using Application.Validators;
using AutoMapper;
using FluentValidation;
using Moq;

namespace PizzaTest;

public class PizzaTest
{
    private IPizzaRepository _pizzaRepository;
    private IMapper _mapper;
    private PostPizzaValidator _postValidator;
    private PizzaValidator _pizzaValidator;

    public PizzaTest()
    {
        
    }
    [Fact]
    public void GetAllPizzas()
    {
        // Arrange

        var Pizza1 = new Pizza() { Name = "Napoli", price = new Price(almPrice: 50, fam40X40Price: 70, fam50X50Price: 80, almGlutenfriPrice: 65), Topping = "Ost, TomatSauce, Peperoni, Cocktailpølser, Dressing" };
        var Pizza2 = new Pizza() { Name = "Magharita", price = new Price(almPrice:45, fam40X40Price: 60, fam50X50Price: 70, almGlutenfriPrice:60), Topping = "Ost, TomatSauce" };
        var Pizza3 = new Pizza() { Name = "Kebab", price = new Price(almPrice:55, fam40X40Price: 70, fam50X50Price: 80, almGlutenfriPrice:68),Topping = "Ost, TomatSauce, Salat, Kebab, Dressing" };
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

    [Fact]
    public void AddPizzaToOrder()
    {
        //Arrange
        Mock<IPizzaOrderRepository> mockRepository = new Mock<IPizzaOrderRepository>();
        IPizzaOrderRepository repository = mockRepository.Object;
        
        //Act
        IPizzaOrderService service = new PizzaOrderService(_mapper, repository);
        
        //Assert
        Assert.NotNull(service);
        Assert.True(service is PizzaOrderService);
    }

    [Fact]
    public void GetPizzaFromOrder()
    {
        //Arrange
        var Pizza1 = new Pizza() { Name = "Napoli", price = new Price(almPrice: 50, fam40X40Price: 70, fam50X50Price: 80, almGlutenfriPrice: 65), Topping = "Ost, TomatSauce, Peperoni, Cocktailpølser, Dressing" };
        var Pizza2 = new Pizza() { Name = "Magharita", price = new Price(almPrice:45, fam40X40Price: 60, fam50X50Price: 70, almGlutenfriPrice:60), Topping = "Ost, TomatSauce" };
        var Pizza3 = new Pizza() { Name = "Kebab", price = new Price(almPrice:55, fam40X40Price: 70, fam50X50Price: 80, almGlutenfriPrice:68),Topping = "Ost, TomatSauce, Salat, Kebab, Dressing" };
        List<Pizza> fakeRepo = new List<Pizza>() { Pizza1, Pizza2, Pizza3 };

        Mock<IPizzaOrderRepository> mockRepository = new Mock<IPizzaOrderRepository>();
        mockRepository.Setup(r => r.GetPizzaFromOrder()).Returns(fakeRepo);

        IPizzaOrderService service = new PizzaOrderService(_mapper, mockRepository.Object);
        
        //Act
        List<Pizza> result = service.GetPizzaFromOrder();
        
        //Assert
        Assert.True(result.Count == 3);
        Assert.Contains(Pizza1,result);
        Assert.Contains(Pizza2,result);
        Assert.Contains(Pizza3,result);
  
        mockRepository.Verify(r => r.GetPizzaFromOrder(), Times.Once);
    }

    [Fact]
    public void DeletePizzaFromOrder()
    {
        //Arrange
        Mock<IPizzaOrderRepository> mockRepository = new Mock<IPizzaOrderRepository>();
        IPizzaOrderService service = new PizzaOrderService(_mapper, mockRepository.Object);
        var Pizza1 = new Pizza() { Name = "Napoli", price = new Price(almPrice: 50, fam40X40Price: 70, fam50X50Price: 80, almGlutenfriPrice: 65), Topping = "Ost, TomatSauce, Peperoni, Cocktailpølser, Dressing" };
        var Pizza2 = new Pizza() { Name = "Magharita", price = new Price(almPrice:45, fam40X40Price: 60, fam50X50Price: 70, almGlutenfriPrice:60), Topping = "Ost, TomatSauce" };
        var Pizza3 = new Pizza() { Name = "Kebab", price = new Price(almPrice:55, fam40X40Price: 70, fam50X50Price: 80, almGlutenfriPrice:68),Topping = "Ost, TomatSauce, Salat, Kebab, Dressing" };
        List<Pizza> fakeRepo = new List<Pizza>() { Pizza1, Pizza2, Pizza3 };
        
        //Act

        service.DeletePizzaFromOrder(2);

        //Assert
        
        mockRepository.Verify(r => r.DeletePizzaFromOrder(2), Times.Once);
    }

    }
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
    /*
    [Fact]
   public void GetAllPizzas()
    {
        // Arrange

        var Pizza1 = new Pizza { Name = "Napoli", AlmPrice = 45, Fam40x40Price = 40, Fam50x50Price = 50, AlmGlutenfriPrice = 60, Topping = "Ost, TomatSauce, Peperoni, Cocktailpølser, Dressing" };
        var Pizza2 = new Pizza { Name = "Magharita", AlmPrice = 45, Fam40x40Price = 40, Fam50x50Price = 50, AlmGlutenfriPrice = 60, Topping = "Ost, TomatSauce" };
        var Pizza3 = new Pizza { Name = "Kebab", AlmPrice = 45, Fam40x40Price = 40, Fam50x50Price = 50, AlmGlutenfriPrice = 60,Topping = "Ost, TomatSauce, Salat, Kebab, Dressing" };
        List<Pizza> fakeRepo = new List<Pizza> { Pizza1, Pizza2, Pizza3 };

        Mock<IPizzaRepository> mockRepository = new Mock<IPizzaRepository>();
        mockRepository.Setup(r => r.GetAllPizzas()).Returns(GetAllPizzas(Order));

        var service = new PizzaService(fakeRepo.new Mock<IPizzaRepository>().Object);
       // IPizzaService service = new PizzaService(mockRepository.Object, _mapper, _postValidator, _pizzaValidator);
        
        // Act
        List<Pizza> result = service.GetAllPizzas();
        // Assert
        Assert.True(result.Count == 3);
        Assert.Contains(Pizza1,result);
        Assert.Contains(Pizza2,result);
        Assert.Contains(Pizza3,result);
  
        mockRepository.Verify(r => r.GetAllPizzas(), Times.Once);
    }

*/    


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
        var Order1 = new PizzaOrder()
            { order = new Order(), pizza = new List<Pizza>(), OrderId = 1, PizzaId = 1, PizzaName = "?" };
        var Order2 = new PizzaOrder() 
            { order = new Order(), pizza = new List<Pizza>(), OrderId = 2, PizzaId = 1, PizzaName = "?" };
        var Order3 = new PizzaOrder() 
            { order = new Order(), pizza = new List<Pizza>(), OrderId = 3, PizzaId = 1, PizzaName = "?" };
        List<PizzaOrder> fakeRepo = new List<PizzaOrder>() { Order1, Order2, Order3 };

        Mock<IPizzaOrderRepository> mockRepository = new Mock<IPizzaOrderRepository>();
        mockRepository.Setup(r => r.GetPizzaFromOrder()).Returns(fakeRepo);

        IPizzaOrderService service = new PizzaOrderService(_mapper, mockRepository.Object);
        
        //Act
        List<PizzaOrder> result = service.GetPizzaFromOrder();
        
        //Assert
        Assert.True(result.Count == 3);
        Assert.Contains(Order1,result);
        Assert.Contains(Order2,result);
        Assert.Contains(Order3,result);
  
        mockRepository.Verify(r => r.GetPizzaFromOrder(), Times.Once);
    }

    [Fact]
    public void DeletePizza()
    {
        //Arrange
        Mock<IPizzaOrderRepository> mockRepository = new Mock<IPizzaOrderRepository>();
        IPizzaOrderService service = new PizzaOrderService(_mapper, mockRepository.Object);
        var Pizza1 = new Pizza() { Name = "String", AlmPrice = 10, Fam40x40Price = 20, Fam50x50Price = 30, AlmGlutenfriPrice = 40, Topping = "String" };
        var Pizza2 = new Pizza() { Name = "Magharita", AlmPrice = 45, Fam40x40Price = 40, Fam50x50Price = 50, AlmGlutenfriPrice = 60, Topping = "Ost, TomatSauce" };
        var Pizza3 = new Pizza() { Name = "Kebab", AlmPrice = 45, Fam40x40Price = 40, Fam50x50Price = 50, AlmGlutenfriPrice = 60,Topping = "Ost, TomatSauce, Salat, Kebab, Dressing" };
        List<Pizza> fakeRepo = new List<Pizza>() { Pizza1, Pizza2, Pizza3 };
        
        //Act

        service.DeletePizza(2);

        //Assert
        
        mockRepository.Verify(r => r.DeletePizza(2), Times.Once);
    }

    }
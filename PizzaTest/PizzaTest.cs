using Application;
using Domain;
using Application.Interfaces;
using Application.Validators;
using AutoMapper;
using Moq;

namespace PizzaTest;

public class PizzaTest
{
    private IPizzaRepository _pizzaRepository;
    private IMapper _mapper;
    private PostPizzaValidator _postValidator;
    private PizzaValidator _pizzaValidator;
    private Mock<IPizzaRepository> pizzaRepoMock = new Mock<IPizzaRepository>();

    public PizzaTest()
    {
    }
    

    [Fact]
    public void GetAllPizzas()
    {
        // Arrange

        var Pizza1 = new Pizza()
        {
            Name = "Pepperoni", AlmPrice = 10, Fam40x40Price = 20, Fam50x50Price = 30, AlmGlutenfriPrice = 40,
            Topping = "Pepperoni"
        };

        var Pizza = new List<Pizza>() { Pizza1, };


        Mock<IPizzaRepository> mockRepository = new Mock<IPizzaRepository>();
        mockRepository.Setup(r => r.GetAllPizzas()).Returns(Pizza);

        IPizzaService service = new PizzaService(mockRepository.Object, _mapper, _postValidator, _pizzaValidator);

        // Act
        var result = service.GetAllPizzas();

        // Assert
        Assert.True(result.Count == 1);
        Assert.Contains(Pizza1, result);

        mockRepository.Verify(r => r.GetAllPizzas(), Times.Once);
    }



// Test to see the addpizzatoOrder method
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

// Test to see the GetPizzaFromOrder method
    [Fact]
    public void GetPizzaOrders()
    {
        //Arrange
        var order1 = new PizzaOrder()
            { order = new Order(), pizza = new List<Pizza>(), OrderId = 1, PizzaId = 1, PizzaName = "?", };

        List<PizzaOrder> fakeRepo = new List<PizzaOrder>() { order1 };

        Mock<IPizzaOrderRepository> mockRepository = new Mock<IPizzaOrderRepository>();
        mockRepository.Setup(r => r.GetPizzaOrders()).Returns(fakeRepo);

        IPizzaOrderService service = new PizzaOrderService(_mapper, mockRepository.Object);

        //Act
        List<PizzaOrder> result = service.GetPizzaOrders();

        //Assert
        Assert.True(result.Count == 1);
        Assert.Contains(order1, result);


        mockRepository.Verify(r => r.GetPizzaOrders(), Times.Once);
    }


//Test to see if the deletePizzaOrdrer is running as it should 
    [Fact]
    public void DeletePizzaOrdrer()
    {
        //Arrange
        Mock<IPizzaOrderRepository> mockRepository = new Mock<IPizzaOrderRepository>();
        IPizzaOrderService service = new PizzaOrderService(_mapper, mockRepository.Object);
        var Pizza1 = new Pizza()
        {
            Id = 1, Name = "String", AlmPrice = 10, Fam40x40Price = 20, Fam50x50Price = 30, AlmGlutenfriPrice = 40,
            Topping = "String"
        };
        List<Pizza> fakeRepo = new List<Pizza>() { Pizza1 };

        //Act

        PizzaOrder result = service.DeletePizzaOrder(1);

        //Assert
        mockRepository.Verify(r => r.DeletePizzaOrder(1), Times.Once);
    }
    
    

    [Fact]
    public void CreatePizzaTest()
    {
        // Arrange
        Mock<IPizzaRepository> repoMock = new Mock<IPizzaRepository>();
        PizzaService? service = null;

        //Act
        service = new PizzaService(repoMock.Object);

        //Assert
        Assert.NotNull(service);
        Assert.True(service is PizzaService);

    }

    [Fact]
    public void CreatePizza_NullRepository()
    {
        //Arrange
        PizzaService? service;

        //Act+Assert
        var ex = Assert.Throws<ArgumentException>(() => service = new PizzaService(null));
        Assert.Equal("Missing PizzaRepository", ex.Message);
    }

    [Fact]
    public void GetPizzaPriceNotNull()
    {
        // Arrange

        var Pizza1 = new Pizza()
        {
            Name = "String", AlmPrice = 10, Fam40x40Price = 20, Fam50x50Price = 30, AlmGlutenfriPrice = 40,
            Topping = "String"
        };

        var Pizza = new List<Pizza>() { Pizza1 };


        Mock<IPizzaRepository> mockRepository = new Mock<IPizzaRepository>();
        mockRepository.Setup(r => r.GetAllPizzas()).Returns(Pizza);

        IPizzaService service = new PizzaService(mockRepository.Object, _mapper, _postValidator, _pizzaValidator);
        
        
        // Act
        var result = service.GetAllPizzas();
        
        // Assert
        Assert.True(Pizza1.AlmPrice != null);
    }
    
    [Fact]
    public void GetPizzaPriceNull()
    {
        // Arrange
        var Pizza1 = new Pizza()
        {
            Name = "String", AlmPrice = null, Fam40x40Price = 0, Fam50x50Price = 0, AlmGlutenfriPrice = 0,
            Topping = "String"
        };

        var Pizza = new List<Pizza>() { Pizza1 };
        
        Mock<IPizzaRepository> mockRepository = new Mock<IPizzaRepository>();
        mockRepository.Setup(r => r.GetAllPizzas()).Returns(Pizza);

        IPizzaService service = new PizzaService(mockRepository.Object, _mapper, _postValidator, _pizzaValidator);
        
        // Act
        var result = service.GetAllPizzas();
        
        // Assert
        Assert.True(Pizza1.AlmPrice != null);
    }

    [Fact]
    public void GetPizzaNameNull()
    {
        // Arrange
        var Pizza1 = new Pizza()
        {
            Name = null, AlmPrice = 0, Fam40x40Price = 0, Fam50x50Price = 0, AlmGlutenfriPrice = 0,
            Topping = "String"
        };

        var Pizza = new List<Pizza>() { Pizza1 };
        
        Mock<IPizzaRepository> mockRepository = new Mock<IPizzaRepository>();
        mockRepository.Setup(r => r.GetAllPizzas()).Returns(Pizza);

        IPizzaService service = new PizzaService(mockRepository.Object, _mapper, _postValidator, _pizzaValidator);
        
        // Act
        var result = service.GetAllPizzas();
        
        // Assert
        Assert.True(Pizza1.Name != null);
    }
    
    
}
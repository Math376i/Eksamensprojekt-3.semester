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
    

//Test to see if the deletePizzaOrdrer is running as it should 
    [Fact]
    public void DeletePizza()
    {
        //Arrange
        Mock<IPizzaRepository> mockRepository = new Mock<IPizzaRepository>();
        IPizzaService service = new PizzaService(_mapper, mockRepository.Object);
        var Pizza1 = new Pizza()
        {
            Id = 1, Name = "String", AlmPrice = 10, Fam40x40Price = 20, Fam50x50Price = 30, AlmGlutenfriPrice = 40,
            Topping = "String"
        };
        List<Pizza> fakeRepo = new List<Pizza>() { Pizza1 };

        //Act

        Pizza result = service.DeletePizza(1);

        //Assert
        mockRepository.Verify(r => r.DeletePizza(1), Times.Once);
    }
    
    

    [Fact]
    public void CreatePizzaTest()
    {
        // Arrange
        Mock<IPizzaRepository> repoMock = new Mock<IPizzaRepository>();
        PizzaService? service = null;

        //Act
        service = new PizzaService(repoMock.Object, _mapper, _postValidator, _pizzaValidator);

        //Assert
        Assert.NotNull(service);
        Assert.True(service is PizzaService);

    }



    [Fact]
    public void GetPizzaAlmPriceNotNull()
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
    public void GetPizzaAlmPriceNull()
    {
        // Arrange
        var Pizza1 = new Pizza()
        {
            Name = "String", AlmPrice = 0, Fam40x40Price = 0, Fam50x50Price = 0, AlmGlutenfriPrice = 0,
            Topping = "String"
        };

        var Pizza = new List<Pizza>() { Pizza1 };

        Mock<IPizzaRepository> mockRepository = new Mock<IPizzaRepository>();
        mockRepository.Setup(r => r.GetAllPizzas()).Returns(Pizza);

        IPizzaService service = new PizzaService(mockRepository.Object, _mapper, _postValidator, _pizzaValidator);

        // Act
        var result = service.GetAllPizzas();

        // Assert
        Assert.False(Pizza1.AlmPrice.Equals(0));
    }
    
    [Fact]
    public void GetPizzaNameNull()
    {
        // Arrange
        var Pizza1 = new Pizza()
        {
            Name = "", AlmPrice = 0, Fam40x40Price = 0, Fam50x50Price = 0, AlmGlutenfriPrice = 0,
            Topping = "String"
        };

        var Pizza = new List<Pizza>() { Pizza1 };
        
        Mock<IPizzaRepository> mockRepository = new Mock<IPizzaRepository>();
        mockRepository.Setup(r => r.GetAllPizzas()).Returns(Pizza);

        IPizzaService service = new PizzaService(mockRepository.Object, _mapper, _postValidator, _pizzaValidator);
        
        // Act
        var result = service.GetAllPizzas();
        
        // Assert
        Assert.True(Pizza1.Name != String.Empty);
    }

    [Fact]
    public void GetToppingTest()
    {
        // Arrange
        var Pizza1 = new Pizza()
        {
            Name = "String", AlmPrice = 0, Fam40x40Price = 0, Fam50x50Price = 0, AlmGlutenfriPrice = 0,
            Topping = "String"
        };

        var Pizza = new List<Pizza>() { Pizza1 };
        
        Mock<IPizzaRepository> mockRepository = new Mock<IPizzaRepository>();
        mockRepository.Setup(r => r.GetAllPizzas()).Returns(Pizza);

        IPizzaService service = new PizzaService(mockRepository.Object, _mapper, _postValidator, _pizzaValidator);
        
        // Act
        var result = service.GetAllPizzas();
        
        // Assert
        Assert.True(Pizza1.Topping != String.Empty);
    }

    [Fact]
    public void GetToppingNotNull()
    {
        // Arrange
        var Pizza1 = new Pizza()
        {
            Name = "String", AlmPrice = 0, Fam40x40Price = 0, Fam50x50Price = 0, AlmGlutenfriPrice = 0,
            Topping = ""
        };

        var Pizza = new List<Pizza>() { Pizza1 };
        
        Mock<IPizzaRepository> mockRepository = new Mock<IPizzaRepository>();
        mockRepository.Setup(r => r.GetAllPizzas()).Returns(Pizza);

        IPizzaService service = new PizzaService(mockRepository.Object, _mapper, _postValidator, _pizzaValidator);
        
        // Act
        var result = service.GetAllPizzas();
        
        // Assert
        Assert.True(Pizza1.Topping != String.Empty);
    }

    [Fact]
    public void GetPizzaFam40x40PriceNotNull()
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
        Assert.True(Pizza1.Fam40x40Price != null);
    }

    [Fact]
    public void GetPizzaFam40x40PriceNull()
    {
        // Arrange
        var Pizza1 = new Pizza()
        {
            Name = "String", AlmPrice = 10, Fam40x40Price = 0, Fam50x50Price = 0, AlmGlutenfriPrice = 0,
            Topping = "String"
        };

        var Pizza = new List<Pizza>() { Pizza1 };

        Mock<IPizzaRepository> mockRepository = new Mock<IPizzaRepository>();
        mockRepository.Setup(r => r.GetAllPizzas()).Returns(Pizza);

        IPizzaService service = new PizzaService(mockRepository.Object, _mapper, _postValidator, _pizzaValidator);

        // Act
        var result = service.GetAllPizzas();

        // Assert
        Assert.False(Pizza1.Fam40x40Price.Equals(0));
    }

    [Fact]
    public void GetPizzaFam50x50PriceNotNull()
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
        Assert.True(Pizza1.Fam50x50Price != null);
    }

    [Fact]
    public void GetPizzaFam50x50PriceNull()
    {
        // Arrange
        var Pizza1 = new Pizza()
        {
            Name = "String", AlmPrice = 10, Fam40x40Price = 20, Fam50x50Price = 0, AlmGlutenfriPrice = 0,
            Topping = "String"
        };

        var Pizza = new List<Pizza>() { Pizza1 };

        Mock<IPizzaRepository> mockRepository = new Mock<IPizzaRepository>();
        mockRepository.Setup(r => r.GetAllPizzas()).Returns(Pizza);

        IPizzaService service = new PizzaService(mockRepository.Object, _mapper, _postValidator, _pizzaValidator);

        // Act
        var result = service.GetAllPizzas();

        // Assert
        Assert.False(Pizza1.Fam50x50Price.Equals(0));
    }

    [Fact]
    public void GetPizzaAlmGlutenfriPriceNotNull()
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
        Assert.True(Pizza1.AlmGlutenfriPrice != null);
    }

    [Fact]
    public void GetPizzaAlmGlutenfriPriceNull()
    {
        // Arrange
        var Pizza1 = new Pizza()
        {
            Name = "String", AlmPrice = 10, Fam40x40Price = 0, Fam50x50Price = 0, AlmGlutenfriPrice = 0,
            Topping = "String"
        };

        var Pizza = new List<Pizza>() { Pizza1 };

        Mock<IPizzaRepository> mockRepository = new Mock<IPizzaRepository>();
        mockRepository.Setup(r => r.GetAllPizzas()).Returns(Pizza);

        IPizzaService service = new PizzaService(mockRepository.Object, _mapper, _postValidator, _pizzaValidator);

        // Act
        var result = service.GetAllPizzas();

        // Assert
        Assert.False(Pizza1.AlmGlutenfriPrice.Equals(0));
    }

    
}
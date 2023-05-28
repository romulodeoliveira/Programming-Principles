# SOLID

Os princípios SOLID são um conjunto de diretrizes de design de software que ajudam a criar código mais limpo, flexível e de fácil manutenção. Esses princípios foram introduzidos por Robert C. Martin (também conhecido como Uncle Bob, foi um dos 17 signatários originais do Manifesto Ágil em 2001 e autor do livro Código Limpo) e são amplamente utilizados na programação orientada a objetos.

Os princípios SOLID são:

## 1. Princípio da Responsabilidade Única (SRP - Single Responsibility Principle):

O SRP estabelece que uma classe deve ter apenas uma única responsabilidade. Isso significa que uma classe deve ter um único motivo para ser modificada. Se uma classe tiver várias responsabilidades, é mais difícil manter e modificar o código. Para aplicar esse princípio, separe as diferentes responsabilidades em classes diferentes. Por exemplo:

```csharp
// Exemplo incorreto
class Cliente
{
    public void EnviarEmail()
    {
        // Lógica para enviar e-mail
    }

    public void CalcularPontuacao()
    {
        // Lógica para calcular pontuação
    }
}
```

```csharp
// Exemplo correto
class ClienteEmailSender
{
    public void EnviarEmail()
    {
        // Lógica para enviar e-mail
    }
}

class ClientePontuacaoCalculator
{
    public void CalcularPontuacao()
    {
        // Lógica para calcular pontuação
    }
}
```

## 2. Princípio Aberto/Fechado (OCP - Open/Closed Principle):

O OCP afirma que as entidades do software (classes, módulos, etc.) devem ser abertas para extensão, mas fechadas para modificação. Isso significa que você deve poder estender o comportamento de uma classe sem modificar o código existente. Isso é alcançado usando polimorfismo e interfaces. Aqui está um exemplo:

```csharp
// Exemplo incorreto
class Forma
{
public string Tipo { get; set; }

    public double CalcularArea()
    {
        double area = 0;

        if (Tipo == "Quadrado")
        {
            // Lógica para calcular área do quadrado
        }
        else if (Tipo == "Círculo")
        {
            // Lógica para calcular área do círculo
        }
        // Mais lógica para outros tipos de formas

        return area;
    }

}
```

```csharp
// Exemplo correto
interface IForma
{
    double CalcularArea();
}

class Quadrado : IForma
{
    public double CalcularArea()
    {
        // Lógica para calcular área do quadrado
    }
}

class Circulo : IForma
{
    public double CalcularArea()
    {
        // Lógica para calcular área do círculo
    }
}
```

## 3. Princípio da Substituição de Liskov (LSP - Liskov Substitution Principle):

O LSP estabelece que os objetos de uma classe base devem ser substituíveis por objetos de suas classes derivadas sem afetar a integridade do programa. Isso significa que as classes derivadas devem ser capazes de substituir as classes base sem causar comportamentos inesperados. Um exemplo disso é quando você herda de uma classe base e substitui um método, mas mantém o contrato original. Veja um exemplo:

```csharp
// Exemplo incorreto
class Retangulo
{
    public virtual void DefinirLargura(int largura)
    {
        // Lógica para definir largura
    }

    public virtual void DefinirAltura(int altura)
    {
        // Lógica para definir altura
    }
}

class Quadrado : Retangulo
{
    public override void DefinirLargura(int largura)
    {
        base.DefinirLargura(largura);
        base.DefinirAltura(largura);
    }

    public override void DefinirAltura(int altura)
    {
        base.DefinirAltura(altura);
        base.DefinirLargura(altura);
    }
}
```

```csharp
// Exemplo correto
abstract class Forma
{
    public abstract void DefinirLargura(int largura);
    public abstract void DefinirAltura(int altura);
}

class Retangulo : Forma
{
    public override void DefinirLargura(int largura)
    {
        // Lógica para definir largura
    }

    public override void DefinirAltura(int altura)
    {
        // Lógica para definir altura
    }
}

class Quadrado : Forma
{
    private int lado;

    public override void DefinirLargura(int largura)
    {
        lado = largura;
    }

    public override void DefinirAltura(int altura)
    {
        lado = altura;
    }
}
```

## 4. Princípio da Segregação de Interfaces (ISP - Interface Segregation Principle):

O ISP estabelece que as interfaces devem ser específicas para os clientes que as utilizam, em vez de serem genéricas demais. Isso evita que os clientes sejam obrigados a depender de métodos que não utilizam. Ao criar interfaces, é melhor ter várias interfaces menores e específicas, em vez de uma única grande interface. Aqui está um exemplo:

```csharp
// Exemplo incorreto
interface ICliente
{
    void EnviarEmail();
    void CalcularPontuacao();
    void RastrearLocalizacao();
}

class Cliente : ICliente
{
    public void EnviarEmail()
    {
        // Lógica para enviar e-mail
    }

    public void CalcularPontuacao()
    {
        // Lógica para calcular pontuação
    }

    public void RastrearLocalizacao()
    {
        // Lógica para rastrear localização
    }
}
```

```csharp
// Exemplo correto
interface IEmailSender
{
    void EnviarEmail();
}

interface IPontuacaoCalculator
{
    void CalcularPontuacao();
}

interface ILocalizacaoTracker
{
    void RastrearLocalizacao();
}

class Cliente : IEmailSender, IPontuacaoCalculator
{
    public void EnviarEmail()
    {
        // Lógica para enviar e-mail
    }

    public void CalcularPontuacao()
    {
        // Lógica para calcular pontuação
    }
}
```

## 5. Princípio da Inversão de Dependência (DIP - Dependency Inversion Principle):

O DIP estabelece que as classes devem depender de abstrações e não de implementações concretas. Isso promove o baixo acoplamento e facilita a substituição de componentes. Em vez de criar dependências diretas entre as classes, você deve depender de interfaces ou abstrações. Veja um exemplo:

```csharp
// Exemplo incorreto
class ClienteService
{
    private ClienteRepository repository;

    public ClienteService()
    {
        repository = new ClienteRepository();
    }

    // Lógica do serviço que usa o repositório
}
```

```csharp
// Exemplo correto
interface IClienteRepository
{
    void SalvarCliente(Cliente cliente);
}

class ClienteRepository : IClienteRepository
{
    public void SalvarCliente(Cliente cliente)
    {
        // Lógica para salvar cliente
    }
}

class ClienteService
{
    private IClienteRepository repository;

    public ClienteService(IClienteRepository repository)
    {
        this.repository = repository;
    }

    // Lógica do serviço que usa o repositório
}
```

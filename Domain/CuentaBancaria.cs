namespace Dsw2025Ej8.Domain;

public class CuentaBancaria
{

    public string Numero { get; }
    public decimal Saldo { get; protected set; }
    public Estado Estado { get; set; }
    public decimal TasaDeInteres { get; init; }
    public decimal LimiteDeDescubierto { get; init; }
    public string[] Titulares { get; set; }
    public TipoCuenta Tipo{ get; set; }

    public CuentaBancaria(string numero, decimal saldo, string[] titulares, TipoCuenta tipo)
    {
        this.Numero = numero;
        this.Saldo = saldo;
        this.Estado = Estado.Activa;
        this.Titulares = titulares;
    
    }

    public virtual bool Depositar(decimal monto, bool flag = false)
    {
        if ( Estado == Estado.Activa)
        {
            if (monto <= 0)
            {
                throw new MontoNoValido();
            }
            Saldo += monto;
            return flag = true;
        }
        else
        {
            throw new CuentaNoActiva(Estado);
        }
    }

    public bool Retirar(decimal monto, bool flag = false)
    {
        if (Estado == Estado.Inactiva || Estado == Estado.Suspendida)
        {
            throw new CuentaNoActiva(Estado);

        }
        else if (monto <= 0)
        {
            throw new MontoNoValido();
        }
        else if (monto > Saldo + LimiteDeDescubierto)
        {
            throw new SaldoInsuficiente();
        }
        else
        {
            Saldo -= monto;

            if (Saldo <= 0)
            {
                Estado = Estado.Suspendida;
                throw new CuentaSuspendida(Numero);
            }
            return flag = true;
        }

            
    }

    public decimal ConsultarSaldo()
    {
        return Saldo;
    }

}

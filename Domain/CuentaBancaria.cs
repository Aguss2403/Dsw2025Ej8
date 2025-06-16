using Dsw2025Ej8.Externals;

namespace Dsw2025Ej8.Domain;

public class CuentaBancaria
{
    private TipoCuenta _tipo;
    private string _numero;
    private decimal _saldo;
    private Estado _estado;
    private decimal _tasaDeInteres;
    private decimal _limiteDeDescubierto;
    private decimal _comision;
    private string[] _titulares;

    public CuentaBancaria(string numero, decimal saldo, TipoCuenta tipo, string[] titulares)
    {
        _numero = numero;
        _saldo = saldo;
        _tipo = tipo;
        _estado = Estado.Activa;
        _titulares = titulares;
    }
    #region Getters/Setters
    public string GetNumero()
    {
        return _numero;
    }

    public decimal GetSaldo()
    {
        return _saldo;
    }
    public TipoCuenta GetTipo()
    {
        return _tipo;
    }

    public Estado GetEstado()
    {
        return _estado;
    }

    public void SetEstado(Estado estado)
    {
        _estado = estado;
    }

    public decimal GetTasaDeInteres()
    {
        return _tasaDeInteres;
    }

    public void SetTasaDeInteres(decimal tasaDeInteres)
    {
        _tasaDeInteres = tasaDeInteres;
    }

    public decimal GetLimiteDeDescubierto()
    {
        return _limiteDeDescubierto;
    }

    public void SetLimiteDeDescubierto(decimal limiteDeDescubierto)
    {
        _limiteDeDescubierto = limiteDeDescubierto;
    }

    public decimal GetComision()
    {
        return _comision;
    }

    public void SetComision(decimal comision)
    {
        _comision = comision;
    }

    public string[] GetTitulares()
    {
        return _titulares;
    }
    #endregion

    public void Depositar(decimal monto)
    {
        if (_estado is Estado.Activa)
        {
            _saldo += monto;
        }
        else
        {
            throw new InvalidOperationException("Tipo de cuenta no soportado para depósito.");
        }
    }

    public void Retirar(decimal monto, IInformarRetiro[] sistemasExternos)
    {
        if (_tipo == TipoCuenta.CajaDeAhorro)
        {
            _saldo += monto;
        }
        else if (_tipo == TipoCuenta.CuentaCorriente)
        {
            if (_saldo - monto >= -_limiteDeDescubierto)
            {
                _saldo += monto;
            }
            if (_saldo < 0)
            {
                _estado = Estado.Suspendida;
            }

        }
        if (sistemasExternos.Length == 0) return;
        foreach (var sistema in sistemasExternos)
        {
            sistema.InformarRetiro(_numero, monto);
        }
    }

    public void AplicarInteres()
    {
        if (_tipo == TipoCuenta.CajaDeAhorro)
        {
            _saldo += _saldo * _tasaDeInteres;
        }
    }

    public void Retirar1(decimal monto, IAgenciaAntiFraude sistemasExternos)
    {
        if (_tipo == TipoCuenta.CajaDeAhorro)
        {
            _saldo += monto;
        }
        else if (_tipo == TipoCuenta.CuentaCorriente)
        {
            if (_saldo - monto >= -_limiteDeDescubierto)
            {
                _saldo += monto;
            }
            if (_saldo < 0)
            {
                _estado = Estado.Suspendida;
            }

        }
        
            sistemasExternos.InformarRetiro(_numero, monto);
        
    }

}

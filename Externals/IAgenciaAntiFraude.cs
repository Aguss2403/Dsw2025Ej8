namespace Dsw2025Ej8.Externals
{
    public interface IAgenciaAntiFraude
    {
        void EstablecerConexion(string url);
        void InformarRetiro(string cuentaNumero, decimal monto);
    }
}
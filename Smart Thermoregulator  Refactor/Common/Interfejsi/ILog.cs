///         INTERFACE ILog
///         Belezenje nove poruke
///         
namespace Common
{
    public interface ILog
    {
        // metoda koja sluzi za belezenje informacionih poruka
        void LogNoveInformationPoruke(string poruka);

        // metoda koja sluzi za belezenje poruka o upozorenju
        void LogNoveWarningPoruke(string poruka);

        // metoda koja sluzi za belezenje poruka o gresci
        void LogNoveErrorPoruke(string poruka);
    }
}

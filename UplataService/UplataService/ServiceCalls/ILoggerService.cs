using UplataService.Models;

namespace UplataService.ServiceCalls
{
    /// <summary>
    /// Interface for LoggerService
    /// </summary>
    public interface ILoggerService
    {
        /// <summary>
        /// Definition of Logger's CreateLog method
        /// </summary>
        /// <param name="loggerDto">LoggerDto instance</param>
        /// <returns></returns>
        public bool CreateLog(LoggerDto loggerDto);
    }
}
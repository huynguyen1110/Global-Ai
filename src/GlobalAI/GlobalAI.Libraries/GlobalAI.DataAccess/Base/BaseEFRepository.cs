using GlobalAI.DataAccess.Models;
using GlobalAI.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
//using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.DataAccess.Base
{
    public class BaseEFRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;
        protected readonly GlobalAIDbContext _globalAIDbContext;
        protected readonly DbSet<TEntity> _dbSet;
        protected readonly string _seqName;
        protected readonly ILogger _logger;

        public const int ORACLE_WRONG_PARAMETERS = 6550;
        public const int ORACLE_USER_HANDLED_EXCEPTION_CODE = 20000;

        public const int ERR_SQL_BASE = 200;
        public const int ERR_SQL_OPEN_CONNECTION_FAIL = ERR_SQL_BASE + 1;
        public const int ERR_SQL_EXECUTE_COMMAND_FAIL = ERR_SQL_BASE + 2;
        public const int ERR_SQL_DISCOVERY_PARAMS_FAIL = ERR_SQL_BASE + 3;
        public const int ERR_SQL_ASSIGN_PARAMS_FAIL = ERR_SQL_BASE + 4;

        public BaseEFRepository(DbContext dbContext, string seqName = null)
        {
            _dbContext = dbContext;
            _globalAIDbContext = dbContext as GlobalAIDbContext;
            _dbSet = dbContext.Set<TEntity>();
            _seqName = seqName;
        }

        public BaseEFRepository(DbContext dbContext, ILogger logger, string seqName = null)
        {
            _dbContext = dbContext;
            _globalAIDbContext = dbContext as GlobalAIDbContext;
            _dbSet = dbContext.Set<TEntity>();
            _seqName = seqName;
            _logger = logger;
        }

        public DbSet<TEntity> Entity => _dbSet;
        public IQueryable<TEntity> EntityNoTracking => _dbSet.AsNoTracking<TEntity>();

        //public decimal NextKey()
        //{
        //    if (_seqName == null)
        //    {
        //        throw new Exception($"Chưa cấu hình sequence cho repository: {this.GetType()}");
        //    }

        //    OracleParameter[] @params =
        //    {
        //        new OracleParameter("SEQ_NAME", OracleDbType.Varchar2) { Direction = ParameterDirection.Input, Value = _seqName },
        //        new OracleParameter("SEQ_OUT", OracleDbType.Decimal) { Direction = ParameterDirection.Output }
        //    };
        //    //_dbContext.Database.ExecuteSqlRaw("BEGIN GET_SEQ(:SEQ_NAME, :SEQ_OUT); END;", @params);
        //    var result = @params[1].Value;
        //    decimal valueResult = decimal.Parse(result.ToString());
        //    return valueResult;
        //}

        //public decimal NextKey(string seqName)
        //{
        //    if (_seqName == null)
        //    {
        //        throw new Exception($"Chưa cấu hình sequence cho repository: {this.GetType()}");
        //    }

        //    OracleParameter[] @params =
        //    {
        //        new OracleParameter("SEQ_NAME", OracleDbType.Varchar2) { Direction = ParameterDirection.Input, Value = seqName },
        //        new OracleParameter("SEQ_OUT", OracleDbType.Decimal) { Direction = ParameterDirection.Output }
        //    };
        //    _dbContext.Database.ExecuteSqlRaw("BEGIN GET_SEQ(:SEQ_NAME, :SEQ_OUT); END;", @params);
        //    var result = @params[1].Value;
        //    decimal valueResult = decimal.Parse(result.ToString());
        //    return valueResult;
        //}

        /// <summary>
        /// Lấy mã lỗi
        /// </summary>
        /// <param name="defError"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string GetDefError(int defError)
        {
            return ErrorMessage.Get(defError);
        }

        /// <summary>
        /// Ném ra ngoại lệ
        /// </summary>
        /// <param name="errorCode"></param>
        /// <exception cref="FaultException"></exception>
        public void ThrowException(ErrorCode errorCode)
        {
            throw new FaultException(new FaultReason(GetDefError((int)errorCode)), new FaultCode(((int)errorCode).ToString()), "");
        }

        /// <summary>
        /// Ném ra ngoại lệ truyền message
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <exception cref="FaultException"></exception>
        public void ThrowException(string errorMessage)
        {
            throw new FaultException(new FaultReason(errorMessage), new FaultCode(((int)ErrorCode.BadRequest).ToString()), "");
        }

        /// <summary>
        /// Ném ra ngoại lệ, kèm dataRef
        /// </summary>
        /// <param name="errorCode"></param>
        /// <exception cref="FaultException"></exception>
        public void ThrowException(ErrorCode errorCode, object dataRef)
        {
            throw new FaultException(new FaultReason(GetDefError((int)errorCode) + $", ref: {dataRef}"), new FaultCode(((int)errorCode).ToString()), "");
        }

        /// <summary>
        /// Log ra ngoại lệ
        /// </summary>
        /// <param name="errorCode"></param>
        public void LogError(ErrorCode errorCode)
        {
            //_logger?.LogError(GetDefError((int)errorCode));
        }

        /// <summary>
        /// Log ra ngoại lệ, kèm dataRef
        /// </summary>
        /// <param name="errorCode"></param>
        /// <exception cref="FaultException"></exception>
        public void LogError(ErrorCode errorCode, object dataRef)
        {
            //_logger?.LogError(GetDefError((int)errorCode) + $", ref: {dataRef}");
        }

        /// <summary>
        /// Check null
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="errorCode"></param>
        public void CheckNull(object entity, ErrorCode errorCode)
        {
            if (entity == null)
            {
                ThrowException(errorCode);
            }
        }

    }

    public static class BaseEFRepositoryExtention
    {
        /// <summary>
        /// Trả về mã lỗi nếu object null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="GlobalAIDbContext"></param>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="FaultException"></exception>
        public static T ThrowIfNull<T>(this T obj, GlobalAIDbContext GlobalAIDbContext, ErrorCode errorCode) where T : class
        {
            if (obj == null)
            {
                string errorMessage = ErrorMessage.Get((int)errorCode);
                throw new FaultException(new FaultReason(errorMessage), new FaultCode(((int)errorCode).ToString()), "");
            }
            return obj;
        }

        public static T ThrowIfNull<T>(this T obj, string message) where T : class
        {
            if (obj == null)
            {
                throw new FaultException(new FaultReason(message), new FaultCode(((int)ErrorCode.BadRequest).ToString()), "");
            }
            return obj;
        }

        /// <summary>
        /// Trả về mã lỗi nếu object null, kèm refer id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="GlobalAIDbContext"></param>
        /// <param name="errorCode"></param>
        /// <param name="dataRef"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="FaultException"></exception>
        public static T ThrowIfNull<T>(this T obj, GlobalAIDbContext GlobalAIDbContext, ErrorCode errorCode, object dataRef) where T : class
        {
            if (obj == null)
            {
                var errCode = (int)errorCode;
                var errorMessages = ErrorMessage.Get(errCode);
                string errorMessage = $"{errorMessages}, (dataRef: {dataRef})";
                throw new FaultException(new FaultReason(errorMessage), new FaultCode(((int)errorCode).ToString()), "");
            }
            return obj;
        }

        /// <summary>
        /// Trả về mã lỗi nếu object null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="errorCode"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        /// <exception cref="FaultException"></exception>
        public static T ThrowIfNull<T>(this T obj, ErrorCode errorCode, string errorMessage) where T : class
        {
            if (obj == null)
            {
                throw new FaultException(new FaultReason(errorMessage), new FaultCode(((int)errorCode).ToString()), "");
            }
            return obj;
        }

        /// <summary>
        /// Log error nếu null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static T LogErrorIfNull<T>(this T obj, ILogger logger, string message) where T : class
        {
            if (obj == null)
            {
                logger.LogError(message);
            }
            return obj;
        }

        /// <summary>
        /// Phân trang
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">Kết quả query muốn phân trang</param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public static PagingResult<T> ToPaging<T>(this IQueryable<T> query, int? pageSize, int? pageNumber) where T : class
        {
            if (pageSize == -1)
            {
                return new PagingResult<T>
                {
                    Items = query,
                    TotalItems = query.Count()
                };
            }
            return new PagingResult<T>
            {
                Items = query.Skip(pageSize * (pageNumber - 1) ?? 0).Take(pageSize ?? 0),
                TotalItems = query.Count()
            };
        }
    }
}

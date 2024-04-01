using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace NewWebApp.Models
{
    public class NewsRepository
    {
        //класс-репозиторий напрямую обращается к контексту базы данных
        private readonly ApplicationContext context;
        public NewsRepository(ApplicationContext context)
        {
            this.context = context;
        }

        //выбрать все записи из таблицы Articles
        public IQueryable<News> GetArticles()
        {
            return context.News.OrderByDescending(x => x.Data);
        }

        //найти определенную запись по id
        public News GetArticleById(Guid id)
        {
            return context.News.Single(x => x.Id == id);
        }

        //сохранить новую либо обновить существующую запись в БД
        public Guid SaveArticle(News entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();

            return entity.Id;
        }

        //удалить существующую запись
        public void DeleteArticle(News entity)
        {
            context.News.Remove(entity);
            context.SaveChanges();
        }
    }
}
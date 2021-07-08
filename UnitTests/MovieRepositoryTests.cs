using Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repos;
using System;

namespace UnitTests
{
    [TestClass]
    public class MovieRepositoryTests
    {
        private readonly MovieRepository _repo = new MovieRepository();

        [TestInitialize]
        public void Arrange()
        {
            Movie movie = new Movie("Toy Story 2", new DateTime(2000, 6, 1));
            _repo.Create(movie);
        }


        [TestMethod]
        public void Create_MovieIsNull_ReturnFalse()
        {
            // Arrange - create any variables we need to test this method
            Movie movie = null;
            MovieRepository repo = new MovieRepository();

            // Act - actually calling the method
            bool result = repo.Create(movie);

            // Assert - making sure the method did what it was supposed to
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Create_MovieIsNotNull_ReturnsTrue()
        {
            // Arrange
            Movie movie = new Movie("A Quiet Place 2", new DateTime(2021, 6, 1));
            MovieRepository repo = new MovieRepository();

            // Act
            bool result = repo.Create(movie);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetById_MovieExists_ReturnMovie()
        {
            // Arrange
            int id = 1;

            // Act
            Movie result = _repo.GetById(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, id);
        }

        [TestMethod]
        public void GetById_MovieDoesNotExist_ReturnNull()
        {
            // Arrange
            int id = 1234;

            // Act
            Movie result = _repo.GetById(id);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void UpdateMovie_MovieDoesNotExist_ReturnsFalse()
        {
            // Arrange 
            int id = 1234;
            Movie updatedMovie = new Movie("Toy Story 3", new DateTime(2004, 12, 25));

            // Act
            bool result = _repo.UpdateMovie(id, updatedMovie);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void UpdateMovie_MovieDoesExist_ReturnsTrue()
        {
            int id = 1;
            Movie updatedMovie = new Movie("Toy Story 3", new DateTime(2004, 12, 25));

            bool result = _repo.UpdateMovie(id, updatedMovie);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UpdateMovie_MovieDoesExist_PropertiesUpdate()
        {
            int id = 1;
            Movie updatedMovie = new Movie("Toy Story 3", new DateTime(2004, 12, 25));

            _repo.UpdateMovie(id, updatedMovie);
            Movie movie = _repo.GetById(id);

            Assert.AreEqual("Toy Story 3", movie.Title);
            Assert.AreEqual(new DateTime(2004, 12, 25), movie.ReleaseDate);
        }

        [TestMethod]
        public void Delete_MovieDoesNotExist_ReturnsFalse()
        {
            int id = 1234;

            bool result = _repo.Delete(id);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Delete_MovieDoesExist_ReturnsTrue()
        {
            int id = 1;

            bool result = _repo.Delete(id);
            //Movie movie = _repo.GetById(id);

            //Assert.IsNull(movie);
            Assert.IsTrue(result);
        }
    }
}

laf1 <- function() {
  a <- matrix(c(1, 2, 3, 2, 3, 4, 1, 1, 1), nrow = 3, byrow = T)
  b <- matrix(c(4, 5, 6, 7, 8, 9, 4, 5, 7), nrow = 3, byrow = T)
  print (a + b)
}

laf2 <- function() {
  a <- matrix(c(1, 2, 3, 2, 3, 4, 1, 1, 1), nrow = 3, byrow = T)
  b <- matrix(c(4, 5, 6, 7, 8, 9, 4, 5, 0), nrow = 3, byrow = T)
  print (a - b)
}

laf3 <- function() {
  a <- matrix(c(1, 2, 2, 3), nrow = 2, byrow = T)
  b <- matrix(c(4, 5, 7, 8), nrow = 2, byrow = T)
  print (a %*% b)
}

laf4 <- function() {
  a <- matrix(c(1, 2, 3, 2, 3, 4, 1, 1, 1), nrow = 3, byrow = T)
  b <- matrix(c(4, 5, 6, 7, 8, 9, 4, 5, 7), nrow = 3, byrow = T)
  print (a %*% b)
}

laf5 <- function() {
  a <- matrix(c(1, 1, 0, 0, 1, 0, 0, 0, 1), nrow = 3, byrow = T)
  b <- a
  for (i in 2:100) {
    b <- b %*% a
  }
  print (b[1,1])
  print (b[1,2])
  print (b[2,2])
  print (b[3,2])
  print (b[3,3])
}

laf7 <- function() {
  a <- matrix(c(-2, -9, 1, 4), nrow = 2, byrow = T)
  b <- a
  for (i in 2:1000) {
    b <- b %*% a
  }
  print (b)
}

laf9 <- function() {
  # https://www.hackerrank.com/challenges/linear-algebra-fundamentals-9-eigenvalues
  a <- matrix(c(0, 1, -2, -3), nrow = 2, byrow = TRUE)
  eigen(a, only.values = TRUE)$values
}

laf10 <- function() {
  # https://www.hackerrank.com/challenges/linear-algebra-fundamentals-10-eigenvectors
  a <- matrix(c(0, 1, -2, -3), nrow = 2, byrow = TRUE)
  eigen(a)$vectors
}

detMatrix1 <- function() {
  # https://www.hackerrank.com/challenges/determinant-of-the-matrix-1
  a <- matrix(c(3,0,0,-2,4, 0,2,0,0,0, 0,1,0,5,-3, -4,0,1,0,6, 0,-1,0,3,2), nrow = 5, byrow = TRUE)
  d <- det(a)
  print(d)
}

eigen1 <- function() {
  # https://www.hackerrank.com/challenges/eigenvalue-of-matrix-1
  a <- matrix(c(1,-3,3, 3,-5,3, 6,-6,4), nrow = 3, byrow = TRUE)
  eigen(a, only.values = TRUE)$values
}

eigen2 <- function() {
  # https://www.hackerrank.com/challenges/eigenvalue-of-matrix-2
  a <- matrix(c(1,2, 2,4), nrow = 2, byrow = TRUE)
  eigen(a, only.values = TRUE)$values
}

eigen3 <- function() {
  # https://www.hackerrank.com/challenges/eigenvalue-of-matrix-3
  a <- matrix(c(2,-1, -1,2), nrow = 2, byrow = TRUE)
  eigen(a, only.values = TRUE)$values
  eigen(a%*%a, only.values = TRUE)$values
}

eigen4 <- function() {
  # https://www.hackerrank.com/challenges/eigenvalue-of-matrix-3
  a <- matrix(c(2,-1, -1,2), nrow = 2, byrow = TRUE)
  I <- matrix(c(1,0, 0,1), nrow = 2, byrow = TRUE)
  library(MASS)
  a_inv <- ginv(a)
  eigen(a_inv, only.values = TRUE)$values
  b <- a - 4*I
  eigen(b, only.values = TRUE)$values
}


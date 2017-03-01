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

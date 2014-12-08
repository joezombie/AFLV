#include <iostream>

long long abs(long long x) { 
  return x > 0 ? x : -x; 
}

int main(void) {
  long long a, b;
  while (std::cin >> a >> b) 
    std::cout << abs(a-b) << std::endl;
  return 0;
}

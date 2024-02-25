#include <iostream>
#define _CRT_SECURE_NO_WARNINGS

void hw1_1(void);
void hw1_2(void);
void hw1_3(void);
void hw1_4(void);

int main()
{
	//hw1_1();
	//hw1_2();
	//hw1_3();
	hw1_4();
	
		

	return 0;
	
}

void hw1_1(void)
{
	std::cout << "hello world " << "im hk" << std::endl;
	int num1, num2, num3, num4, num5; //정수 5개를 위한 변수 정의


	std::cout << "1번째 정수 입력: ";
	std::cin >> num1;					//num@에 숫자 입력

	std::cout << "2번째 정수 입력: ";
	std::cin >> num2;

	std::cout << "3번째 정수 입력: ";
	std::cin >> num3;

	std::cout << "4번째 정수 입력: ";
	std::cin >> num4;

	std::cout << "5번째 정수 입력: ";
	std::cin >> num5;

	int add = num1 + num2 + num3 + num4 + num5;	//합계 변수 정의

	std::cout << "합계: " << add << std::endl;

}
void hw1_2(void)
{
	char name[100], phone[100];		//이름과 전화번호를 담기 위한 배열 변수 정의

	std::cout << "what is your name: ";
	std::cin >> name;

	std::cout << "what is your phone num:";
	std::cin >> phone;

	std::cout << "your name is " << name << " your phone number is " << phone << std::endl;


}
void hw1_3(void)
{
	int num;		//구구단을 위한 숫자 변수 정의
	std::cout << "구구단 출력을 위해 숫자를 입력하시오: ";
	std::cin >> num;	//숫자입력

	for (int i = 1; i < 10; i++)		//1단부터 9단까지 나오기 위해 반복문 사용
	{
		std::cout << i << "x" << num << "=" << i * num << std::endl;
	}
}
void hw1_4(void)
{
	int salary, money;
	
	
	while (true)
	{
		std::cout <<"판매 금액을 만원 단위로 입력(-1 to end): ";
		std::cin >> money;
		salary = money * 0.12 + 50;	//급여계산기

		if (money == -1)		//-1을 치면 종료
			break;

		std::cout << "이번 달 급여: " << salary << std::endl;
		
	}
}
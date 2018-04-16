// Ntreev.Crema.CodeTest-vc141.cpp: 콘솔 응용 프로그램의 진입점을 정의합니다.
//

#include "stdafx.h"
#include "crema_tables.h"
#include <iostream>

int main()
{
	CremaCode::CremaDataSet* dataSet = new CremaCode::CremaDataSet("..\\..\\crema.dat", false);
	std::cout << dataSet->name() << std::endl;
	std::cout << dataSet->revision() << std::endl;
	std::cout << dataSet->typesHashValue() << std::endl;
	std::cout << dataSet->tablesHashValue() << std::endl;
	std::cout << dataSet->tags() << std::endl;
	return 0;
}


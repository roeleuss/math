#include <iostream>
#include <iomanip>
#include <cstdlib>
#include <chrono>
#include <random>
#include "BinarySet.h"

using namespace std;
using namespace std::chrono;


long long now();
int next_random(int max);
void populate(BinarySet *set);
void count(BinarySet *set);
void remove(BinarySet *set);
void search(BinarySet *set);

const int DEFAULT_LOOP = 100;
int loop;

int main(int numberOfArgs, char *args[]) 
{
    if (numberOfArgs > 0) 
    {
        loop = atoi(args[1]);
    }

    if (loop == 0) loop = DEFAULT_LOOP;

    auto set = new BinarySet();
    populate(set); 
    count(set);
    search(set);
    remove(set);
    count(set);

    return 0;
}


void count(BinarySet *set) 
{
    auto init = now();
    int count = set->count();
    auto end = now();
    int interval = end - init;
    cout << "Elapse Time to Count " << setw(17) << count << " elements: " << setw(10) << interval << " milliseconds" << endl;
}

void populate(BinarySet *set) 
{
    std::random_device seed;
    std::mt19937 engine(seed());
    std::uniform_int_distribution<> random(0, loop - 1);

    auto init = now();
    for (int i = 0; i < loop; i++)
    {
         set->addElement(random(engine));
    }
    auto end = now();
    int interval = end - init;
    cout << "Elapse Time to Try Populate " << setw(10)  << loop << " elements: " << setw(10) << interval << " milliseconds" << endl;
}

long long now() 
{
    return duration_cast<milliseconds>(system_clock::now().time_since_epoch()).count();
}

void remove(BinarySet *set) 
{
    std::random_device seed;
    std::mt19937 engine(seed());
    std::uniform_int_distribution<> random(0, loop - 1);    

    auto init = now();
    for (int i = 0; i < loop; i++)
    {
        set->removeElement(random(engine));
    }
    auto end = now();
    int interval = end - init;
    cout << "Elapse Time to Try Remove " << setw(12)  << loop << " elements: " << setw(10) << interval << " milliseconds" << endl;
}

void search(BinarySet *set)
{
    std::random_device seed;
    std::mt19937 engine(seed());
    std::uniform_int_distribution<> random(0, loop - 1);    

    auto init = now();
    int found = 0;
    for (int i = 0; i < loop; i++)
    {
        if (set->contains(random(engine)))
        {
            found++;
        }
    }
    auto end = now();
    int interval = end - init;
    cout << "Elapse Time to Found " << setw(17)  << found << " elements: " << setw(10) << interval << " milliseconds" << endl;
}
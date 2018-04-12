using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static int intelligence;
    static int totalBulletShot;
    static int bulletPrice;
    static List<int> bullets;

    static void Main(string[] args)
    {
        // Input 
        bulletPrice = int.Parse(Console.ReadLine());
        var SizeOfGunBarrel = int.Parse(Console.ReadLine());

        // bullets sequance
        bullets = Console.ReadLine().Split().Select(int.Parse).ToList();
        var locks = Console.ReadLine().Split().Select(int.Parse).ToList();

        // intelligence 
        intelligence = int.Parse(Console.ReadLine());

        //Stack for bullets
        Stack bulletStack = new Stack();
        for (int i = 0; i < bullets.Count; i++)
        {
            bulletStack.Push(bullets[i]);
        }

        //Queue for locks
        Queue LockQueue = new Queue();
        for (int i = 0; i < locks.Count; i++)
        {
            LockQueue.Enqueue(locks[i]);
        }

        //current variables for index of bullets and locks
        int shotCountIndex = 0;
        // variables for all bullets shot
        totalBulletShot = 0;

        while (true)
        {
            totalBulletShot++;

            var currentBullet = (int)bulletStack.Peek();
            var currentLock = (int)LockQueue.Peek();

            if (currentBullet > currentLock)
            {
                Console.WriteLine("Ping!");

            }
            else
            {
                Console.WriteLine("Bang!");
                LockQueue.Dequeue();
            }
            // removing bullet from the seqauance
            bulletStack.Pop();

            //check for realoding
            shotCountIndex++;
 
            if (bulletStack.Count == 0)
            {
                if (LockQueue.Count == 0)
                {
                    PrintResult();
                    break;
                }
                var locksLeft = LockQueue.Count;
                Console.WriteLine($"Couldn't get through. Locks left: {locksLeft}");
                break;
            }
            if (shotCountIndex == SizeOfGunBarrel)
            {
                Console.WriteLine("Reloading!");
                shotCountIndex = 0;
            }
            if (LockQueue.Count == 0)
            {
                PrintResult();
                break;
            }


        }

    }

    private static void PrintResult()
    {
        var totalPriceForBullets = totalBulletShot * bulletPrice;
        var resultPrice = Math.Abs(intelligence - totalPriceForBullets);
        var bulletsLeft = Math.Abs(totalBulletShot - bullets.Count);

        if (bulletsLeft <= 0)
        {
            bulletsLeft = 0;
        }
        Console.WriteLine($"{bulletsLeft} bullets left. Earned ${resultPrice}");
    }
}


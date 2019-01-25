using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadSort
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sorting in ascending order using SPREADSORT
            int a;
            Console.WriteLine("---------SPREAD SORT---------");
            Console.WriteLine("How many elements you want to enter : ");
            a = Convert.ToInt32(Console.ReadLine());

            int[] arr = new int[a];
            Console.WriteLine("Enter {0} Elements",a);
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            
            SPREADSORT s = new SPREADSORT();
            s.BucketSort(arr);

        }
    }
    class SPREADSORT
    {
        //using BucketSort and QuickSort
        public void BucketSort(int [] arr)
        {
            int maxVal = arr[0];
            int minVal = arr[0];
            List<int[]> a = new List<int[]>();
            for (int i = 1; i < arr.Length; i++)
            {
                if(arr[i]>maxVal)
                {
                    maxVal = arr[i];
                }
                if(arr[i]<minVal)
                {
                    minVal = arr[i];
                }
            }
            // Creating Buckets and Initializing each bucket in loop
            List<int>[] Bucket = new List<int>[maxVal - minVal + 1];
            for (int j = 0; j < Bucket.Length; j++)
            {
                Bucket[j] = new List<int>();
            }
            //Adding values in buckets
            for (int k = 0; k <arr.Length; k++)
            {
                Bucket[arr[k] - minVal].Add(arr[k]);
                
            }
            //Now applying Quick Sort on each Bucket
            for (int l = 0; l < Bucket.Length; l++)
            {
                a.Add(QuickSort(Bucket[l].ToArray(), Bucket[l].Count-1, 0));
            }

            Console.WriteLine("SORTED!\n");
                foreach (var item in a)
                {
                    foreach (var item2 in item)
                    {
                        Console.WriteLine(item2);
                    }
                }
           
            
        }
        public int[] QuickSort(int [] bucket,int high,int low)
        {
            if (low<high)
            {
                int pivot_loc = Partition(bucket, low, high);
                QuickSort(bucket, pivot_loc -1, high); 
                QuickSort(bucket, low, pivot_loc + 1);
                
            }
            return bucket;
        }
        private int Partition(int [] bucket,int low,int high )
        {
            int pivot = bucket[high];//Making last element pivot
            int x = low-1; 
            for (int i = low; i <high-1; i++)
            {
                if(bucket[i] > pivot)
                {
                    
                    swap(bucket, x, i);
                    x++;
                }
            }
            swap(bucket, x+1, high);
            return x ;
        }

        private void swap(int [] array,int a,int b)
        {
            int temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }
    }
}

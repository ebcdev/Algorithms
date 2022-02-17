Heap heap=new Heap();
var values=new int [] {4,1,3,2,16,9,10,14,8,7};
var maxHeap=heap.BuildMaxHeap(values);

values.ToList().ForEach(a=>Console.Write($"{a}-"));
maxHeap.ToList().ForEach(a=>Console.Write($"{a}-"));


public class Heap{

 
    

    public int[] BuildMaxHeap(int [] heap){
        int heapSize=heap.Length;
        for(int i=heapSize/2-1;i>=0;i--){
            heap=MaxHeapify(heap,i);
        }
        return heap;
    }


    public int [] MaxHeapify(int [] A,int i){
        int left =i.Left();
        int right=i.Right();

        int largest =0;
       

        if(left<A.Length && A[left]>A[i]){
            largest=left;
        }else{
            largest=i;
        }

        if(right<A.Length && A[right]>A[largest]){
            largest=right;
        }

        if(largest!=i){
            var temp =A[i];
            A[i]=A[largest];
            A[largest]=temp;
            return MaxHeapify(A,largest);
        }
        return A;
        
    }


  

   



}

public static class Extensions{
    public static int Parent(this int i){
        return (i+1)/2-1;
    }

    public static int Left(this int i){
        return 2*(i+1)-1;
    }

    public static int Right(this int i){
        return 2*(i+1);
    }
}
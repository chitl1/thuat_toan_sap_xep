// See https://aka.ms/new-console-template for more information


//class dùng chung
static class Util
{
    public static int[] NhapMang()
    {
        //Nhap mang
        Console.Write("Nhap so luong phan tu n = ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[] a = new int[n];
        Console.WriteLine("Nhap cac phan tu trong mang");
        for (int i = 0; i < n; i++)
        {
            Console.Write(" a[{0}] = ", i);

            a[i] = Convert.ToInt16(Console.ReadLine());
        }
        return a;
    }
    public static void InMAng(int[] a)
    {
        //In mang
        int n = a.Length;
        Console.WriteLine("\n Cac phan tu trong mang sau sap xep");
        for (int i = 0; i < n; i++)
        {
            Console.Write(" a[{0}] = {1} \t", i, a[i]);
        }
    }
    public static void HoanDoi(ref int a, ref int b)
    {
        //Đổi chỗ
        int temp = a;
        a = b;
        b = temp;
    }
}

class HocThuatToanSapXep
{
    static void Main(string[] args)
    {
        int[] a = Util.NhapMang();
        Util.InMAng(a);
        //Sap xep mang
        //bubbleSort.sapXep(a);
        //selectionSort.sapXep(a);
        //InsertionSort.sapXep(a);
        //QuickSort.SapXepLomuto(a, 0, a.Length -1 );
        QuickSort.SapXepHoare(a, 0, a.Length - 1);
        Util.InMAng(a);
    }
}


////1. sắp xếp nổi bọt
public static class bubbleSort
{
    //so sánh 2 số cạnh nhau -> tìm ra số lớn nhất hoặc hoặc nhất ở cuối của mảng
    //lặp lại quá trình so sánh từ vị trí 0 -> n-1 ( vì vị trí cuối cùng là giá trị lớn nhất hoặc nhỏ nhất tìm ra trong vòng lặp đầu tiên)

    public static int[] sapXep(int[] a)
    {
        int step = 0;
        int n = a.Length;
        for (int i = 0; i < n - 1; i++)
        {
            bool swapped = false;
            for (int j = 0; j < n - 1 - i; j++)
            {
                if (a[j] > a[j + 1])
                {
                    int temp = a[j];
                    a[j] = a[j + 1];
                    a[j + 1] = temp;
                    swapped = true;
                }
                step++;
                Console.WriteLine("So vong lap : {0}", step);
            }
            if (!swapped) break;
        }
        return a;
    }
}


//2. sắp xếp chọn
public static class selectionSort
{
    // lặp n - 2 lần
    // mảng chạy từ 0 -> n-1;

    //tìm trong mảng ra phần tử nhỏ nhất -> chuyển về vị trí đầu của mảng.
    //lặp từ vị trí i = i+ 1;
    //dừng vòng lặp khi i = n - 1

    public static int[] sapXep(int[] a)
    {
        int step = 0;
        int n = a.Length;
        for (int i = 0; i < n; i++)
        {
            // tìm giá trị nhỏ nhất trong mảng từ vị trí i -> n-1;
            int min = a[i];
            int chisoMin = i;
            int temp;
            int j;

            for (j = i + 1; j < n; j++)
            {
                step += 1;
                if (a[j] < min)
                {
                    min = a[j];
                    chisoMin = j;
                }
            }

            temp = a[i];
            a[i] = min;
            a[chisoMin] = temp;

        }
        return a;
    }

    public static int timMin(int[] a)
    {
        int min = a[0];
        int chisoMin = 0;
        for (int i = 0; i < a.Length - 1; i++)
        {
            if (a[i] < min)
            {
                min = a[i];
                chisoMin = i;
            }
        }
        return chisoMin;
    }
}


//3. Sắp xếp chèn
public static class InsertionSort
{
    public static int[] sapXep(int[] a)
    {
        //tìm vị trí cho phần tử thứ i trong mảng.
        int n = a.Length;
        int key; // 
        for (int i = 1; i < n; i++)
        {
            //gán key = a[i]
            key = a[i];
            //so sánh key với mảng trước đó
            int j = i - 1;
            while (j >= 0 && a[j] > key)
            {
                a[j + 1] = a[j];
                j--;
            }
            // Chèn `key` vào vị trí đúng
            a[j + 1] = key;
        }
        return a;
    }
}

//4. Sắp xếp nhanh
public static class QuickSort
{
    //phân hoạc lomuto
    public static void SapXepLomuto(int[] a, int csd, int csc)
    {
        if (csd >= csc) return;
        int p = Partition(a, csd, csc);
        SapXepLomuto(a, csd, p - 1);
        SapXepLomuto(a, p + 1, csc);
    }

    public static int Partition(int[] a, int csd, int csc)
    {
        int pivot = a[csc];
        int j = csd - 1;
        int chisocuapivot = csc;
        for (int i = csd; i <= csc; i++)
        {
            if (a[i] <= pivot)
            {
                j++;
                if (a[j] > a[i])
                {
                    int temp = a[i];
                    a[i] = a[j];
                    a[j] = temp;

                }
            }
        }

        return j; // Trả về vị trí của pivot
    }

    //phân hoạch hoare
    public static void SapXepHoare(int[] a, int csd, int csc)
    {
        if (csd >= csc) return;
        int p = PartitionHoare(a, csd, csc);
        SapXepHoare(a, csd, p);
        SapXepHoare(a, p + 1, csc);
    }
    public static int PartitionHoare(int[] a, int csd, int csc)
    {
        int i = csd - 1;
        int j = csc + 1;
        int pivot = a[csd];
        while (true)
        {
            do
            {
                ++i;
            }
            while (a[i] < pivot);
            do
            {
                --j;
            }
            while (a[j] > pivot);
            if (i < j)
            {
                //Swap.HoanDoi(a[i], a[j]);
                Util.HoanDoi(ref a[i], ref a[j]);
            }
            else return j;

        }
    }
}

using System;

namespace check
{
    class MainClass
    {
        public static piece[,] game_board = new piece[8, 8];

        public static void Main(string[] args)
        {  
            rook br1 = new rook(0,0);
            rook br2 = new rook(0, 3);

            game_board[0, 0] = br1;
            game_board[0, 1] = br2;

            br1.move(0, 2);
           
            Console.WriteLine("dssfsdsdcsadasdasda");


        }

        
    }


    
    abstract class piece {
        public int x{ get; set; }
        public int y { get; set; }

    }



    class rook : piece
    {
        
        

        public rook(int one, int two)
        {
            this.x = one;
            this.y = two;
        }

        public bool move(int newx, int newy)
        {

            if (this.check_move(newx, newy))
            {
                this.x = newx;
                this.y = newy;
                Console.WriteLine("valid");
                return true;
                
            }
            Console.WriteLine("invalid");
            return false;
        }

        public bool check_move(int newx, int newy)
        {
            piece[,] temp_b = MainClass.game_board;

            if (newx == this.x)
            {
                int v = Math.Abs(newy - this.y);
                Console.WriteLine(v);
                if (newy > this.y)
                {
                    for (int i = 1; i <= v; i++)
                    {
                        Console.WriteLine("one "+i);
                        if (temp_b[this.x , this.y+i] != null)
                        {
                            Console.WriteLine("two "+i);
                            return false;
                        }
                        return true;
                    }
                }
                //this is when the new pos is on the left of the original position
                else if (newy < this.y)
                {
                    for (int i = 1; i < v; i++)
                    {
                        if (temp_b[this.x , this.y-i] != null)
                        {
                            Console.WriteLine(i);
                            return false;
                        }
                        return true;
                    }
                }

            }
            else if(newy == this.y)
            {
                //getting the abs value of difference between the new value and the old
                int v = Math.Abs(newx - this.x);
                Console.WriteLine(v);
                //when new pos is on the right of the original position
                if (newx > this.x)
                {
                    for (int i = 1; i < v; i++)
                    {
                        if (temp_b[this.x + i, this.y] != null)
                        {
                            return false;
                        }
                        return true;
                    }
                }
                //this is when the new pos is on the left of the original position
                else if (newx <this.x)
                {
                    for (int i = 1; i < v; i++)
                    {
                        if (temp_b[this.x - i, this.y] != null)
                        {
                            return false;
                        }
                        return true;
                    }
                }
            }
            // if the new pos is the same as the original move is invalid
            else if (newy==this.y && newx == this.x )
            {
                return false;
            }

            return false;
        }
    }
    

}


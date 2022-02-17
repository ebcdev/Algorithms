BinaryTree tree=new BinaryTree();

tree.Insert(15);
tree.Insert(6);
tree.Insert(7);
tree.Insert(13);
tree.Insert(9);
tree.Insert(3);
tree.Insert(2);
tree.Insert(4);
tree.Insert(18);
tree.Insert(17);
tree.Insert(20);
tree.Insert(19);


tree.InorderTreeWalkRecursive();

var search=tree.Search(20);
Console.WriteLine($"Trees succesor={tree.TreeSuccesor(search)}");
Console.WriteLine($"Trees predecessor={tree.TreePredeccesor(search)}");

public class BinaryTree{

    private Node root;  


 

     public void InorderTreeWalkRecursive(){        
      DoInorderTreeWalk(root);
    }

    private void DoInorderTreeWalk(Node node){
        if(node==null)return;
        DoInorderTreeWalk(node.Left);
        Console.WriteLine(node.Key);
        DoInorderTreeWalk(node.Right);
    }
    

    public void Insert(int key){
        if(root==null){
            root=new Node{Key=key};
        }else{
            Insert(root,key);
        }
    }
    public Node Search(int key){       
        var x=root;
        while(x!=null&&x.Key!=key){                             
            if(key<x.Key){
                x=x.Left;
            }
            if(key>x.Key){
                x=x.Right;
            }
        }
        return x;
    }

    public Node Minimum(Node node=null){
        var x=node==null?root:node;
        while(x.Left!=null){
            x=x.Left;
        }
        return x;
    }


    public Node Maximum(Node node=null){
        var x=node==null?root:node;
        while(x.Right!=null){
            x=x.Right;
        }
        return x;
    }

    public Node TreeSuccesor(Node x){
        if(x.Right!=null){
            return Minimum(x.Right);
        }
        var y=x.Parent;
        while(y!=null && x==y.Right){
            x=y;
            y=y.Parent;
        }
        return y;
    }


    public Node TreePredeccesor(Node x){
        if(x.Left!=null){
            return Maximum(x.Left);
        }
        var y=x.Parent;
        while(y!=null&&x==y.Left){
            x=y;
            y=y.Parent;
        }
        return y;
    }

 

    private void Insert(Node parent, int key){
        if(key<=parent.Key){
            if(parent.Left!=null){
                Insert(parent.Left,key);
            }else{
                parent.Left=new Node{Key=key,Parent=parent};
            }                
        }else if(key>=parent.Key){
            if(parent.Right!=null){
                Insert(parent.Right,key);
            }else{
                parent.Right=new Node{Key=key,Parent=parent};
            }
        }
    }

}


public class Node{
    public int Key { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public Node Parent { get; set; }

    public override string ToString()
    {
        return $"{Key}";
    }
}
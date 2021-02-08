using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///     constuctor: special methods; call method in a class
///                 creates instance of an object
///     properties: special methods; getter & setter (doesn't need arguments)
///                 performs function within the library
///                 
///     TASK:
///         Insert a new value
///         Check if a value is present
///         Depth of the tree 
///         Sum the tree 
///         Lowest common ancestor of two values
///         Delete a value 
///         Output in order, i.e. In-order traversal 
/// </summary>

namespace BinaryTree.Lib
{
    internal class BinaryTree
    {
        private BinaryTreeNode root;      // root position (the container)
        public BinaryTreeNode Root
        {   get { return root; }   }

        internal BinaryTree()
        {
            // default constructor: null
        }

        internal BinaryTree(int rootval)
        {
            // default constructor: with root value taken in
            root = new BinaryTreeNode(rootval);      // generates an root node with initial I/P integer stored
        }

        internal void Append(int newvalue)
        {
            if (root == null)          // base case
                root = new BinaryTreeNode(newvalue);    // if empty, add a node
            root.Append(newvalue);     // passes into the binarytreenode class method
        }

        internal void Remove(int existedvalue)
        {
            if (root == null)
                throw new ArgumentNullException();
            root.Remove(existedvalue, Root);    
            // it passed into the node class because user SHOULDN'T input the root node
        }

        internal bool IsRepeated(int newvalue)
        {
            return (newvalue == 1);
        }
    }

    internal class BinaryTreeNode
    {
        private int value;              // head value
        internal int Value
        {   get { return value; }  }

        private BinaryTreeNode lhs;    
        internal BinaryTreeNode LHS     // keep lhs private, call LHS instead within the namespace
        {   get { return lhs; }
            set { lhs = value; }    }

        private BinaryTreeNode rhs;
        internal BinaryTreeNode RHS
        {   get { return rhs; }
            set { rhs = value; }    }
        
        internal BinaryTreeNode (int newvalue)
        {   value = newvalue;      }    // value container


        internal void Append (int newvalue)
        {
            // selection
            if (lhs == null && newvalue < value)
                lhs = new BinaryTreeNode(newvalue);    // add a new left node (from null)
            
            else if (rhs == null && newvalue >= value)
                rhs = new BinaryTreeNode(newvalue);    // add a new right node (from null)
            
            (newvalue >= value ? rhs : lhs).Append(newvalue);        // tenary operator + recursion
            // Apply .Append on _LHS or _RHS via recursion
        }

        internal void Remove (int disposedvalue, BinaryTreeNode ROOT)
        {
            BinaryTreeNode AncestorNode = ROOT;     // the ancestor of a root node is itself
            BinaryTreeNode CurrentNode = ROOT;
            bool IsOnLHS = false;
            
            while (CurrentNode != null && CurrentNode.Value != disposedvalue)
            {
                AncestorNode = CurrentNode;         // it's going down the tree
                CurrentNode = (disposedvalue < value ? CurrentNode.lhs : CurrentNode.rhs);
                IsOnLHS = (disposedvalue < value ? true : false);
                // goes AFTER line "AncestorNode = CurrentNode" because LOOP STOPS when CurrentNode contains the value
            }
            // afterthe node found, AncestorNode contains parent value; CurrentNode is one step beyond

            // Left 0 Right 0: leaf
            if (CurrentNode.LHS == null && CurrentNode.RHS == null)
            {
                // base case: root
                if (CurrentNode == ROOT)
                    throw new FieldAccessException("Accessibility of Root sucks");
                else
                {
                    AncestorNode.LHS = null;
                    AncestorNode.RHS = null;
                }
            }
            // Left 1 Right 0: 1 child
            else if (CurrentNode.RHS == null)
            {
                if (CurrentNode == ROOT)
                    throw new FieldAccessException("Accessibility of Root sucks");
                else
                {
                    if (IsOnLHS)     // checks CurrentNode's relation to AncestorNode
                        AncestorNode.LHS = CurrentNode.LHS;
                    else
                        AncestorNode.RHS = CurrentNode.LHS; // CurrentNode.LHS < AncestorNode
                }
            }
            // Left 0 Right 1: 1 child 
            else if (CurrentNode.LHS == null)
            {
                if (CurrentNode == ROOT)
                    throw new FieldAccessException("Accessibility of Root sucks");
                else
                {
                    if (IsOnLHS)
                        AncestorNode.LHS = CurrentNode.RHS;
                    else
                        AncestorNode.RHS = CurrentNode.RHS;
                }
            }
            // Left 0 Right 0: 2 children
            else
            {
                if (CurrentNode == ROOT)
                    throw new FieldAccessException("Accessibility of Root sucks");
                else
                {

                }
            }
            if (CurrentNode == null)
                throw new ArgumentNullException("This is an Empty Tree ...");
        }

        internal bool IsLeaf(BinaryTreeNode thenode)
        {
            return (lhs == null && rhs == null);
        }

        internal bool IsOneSideStem(BinaryTreeNode thenode)
        {
            return (lhs == null ^ rhs == null);
        }

        internal bool IsRepeated(int newvalue)
        {
            if (lhs == null || rhs == null)
            {
                return false;
            }
        }
    }
}


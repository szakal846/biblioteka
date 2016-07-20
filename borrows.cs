using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
     class Borrow
    {

        private int BorrowData { set; get; }
        private int ReturnData { set; get; }
        private int UserId { set; get; }
        private int BookId { set; get; }
        private Borrow() { }
        public Borrow(int borrowData, int returnData, int userId, int bookId)
        {
            this.BorrowData = borrowData;
            this.ReturnData = returnData;
            this.UserId = userId;
            this.BookId = bookId;

        }


    }
    
}

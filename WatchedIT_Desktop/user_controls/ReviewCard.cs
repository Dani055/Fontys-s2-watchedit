using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WatchedIT_Desktop.user_controls
{
    public partial class ReviewCard : UserControl
    {
        private int id;
        private int userId;
        private string firstname;
        private string lastname;
        private string userimg;
        private string description;
        private int rating;

        public int Id { get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public int UserId
        {
            get
            {
                return userId;
            }
            set
            {
                userId = value;
            }
        }
        public string FirstName
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
                if (userId == AuthClass.loggedUser.Id)
                {
                    lblName.Text = "You";
                }
                else
                {
                    lblName.Text = value + " " + lastname;
                }
                
            }
        }
        public string LastName
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
                if (userId == AuthClass.loggedUser.Id)
                {
                    lblName.Text = "You";
                }
                else
                {
                    lblName.Text = firstname + " " + value;
                }
                
            }
        }
        public string UserImg
        {
            get
            {
                return userimg;
            }
            set
            {
                userimg = value;
                if (userimg != null)
                {
                    pictureBox1.Load(userimg);
                }
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                tbDesc.Text = description;
            }
        }
        public int Rating
        {
            get
            {
                return rating;
            }
            set
            {
                rating = value;
                lblRating.Text = rating.ToString();
            }
        }
        public ReviewCard(int id, int userId, string firstname, string lastname, string userimg, string description, int rating)
        {
            InitializeComponent();
            Id = id;
            UserId = userId;
            FirstName = firstname;
            LastName = lastname;
            UserImg = userimg;
            Description = description;
            Rating = rating;
        }
    }
}

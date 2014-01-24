using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Telerik.Everlive.Sdk.Core.Model.Interfaces;
using Telerik.Everlive.Sdk.Core.Serialization;
using Telerik.Windows.Controls.Cloud.Sample.Helpers;
using Telerik.Windows.Cloud;
using Telerik.Everlive.Sdk.Core;

namespace Telerik.Windows.Controls.Cloud.Sample.Models
{
    [ServerType(ServerTypeName = "Activities")]
    public class Activity : EverliveDataItem, IDataItem
    {
        #region Properties
        
        /// <summary>
        /// The text for the activity.
        /// </summary>
        private string text;
        
        public string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                this.SetProperty(ref this.text, value, "Text");
            }
        }
        
        /// <summary>
        /// The ID of the user who created(shared) the activity.
        /// </summary>
        private Guid userId;
        
        public Guid UserId
        {
            get
            {
                return this.userId;
            }
            set
            {
                this.SetProperty(ref this.userId, value, "UserId");
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        private Guid pictureFileId;
        
        [ServerProperty("Picture")]
        public Guid PictureFileId
        {
            get
            {
                return this.pictureFileId;
            }
            set
            {
                this.SetProperty(ref this.pictureFileId, value, "PictureFileId");
            }
        }
        
        /// <summary>
        /// Contains the IDs of the users who liked the activity.
        /// </summary>
        private List<Guid> likes;
        
        public List<Guid> Likes
        {
            get
            {
                return this.likes;
            }
            set
            {
                this.SetProperty(ref this.likes, value, "Likes");
                this.OnPropertyChanged(new PropertyChangedEventArgs("LikesCount"));
                this.OnPropertyChanged(new PropertyChangedEventArgs("LikesCountString"));
                this.OnPropertyChanged(new PropertyChangedEventArgs("LikesAndCommentsCount"));
            }
        }
        
        #endregion
        
        #region ViewModel Properties
        
        [ServerIgnore]
        public string AuthorName
        {
            get
            {
                if (this.userDisplayName == null)
                {
                    this.RetrieveDisplayName();
                }
                return this.userDisplayName;
            }
            protected set
            {
                this.userDisplayName = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("AuthorName"));
            }
        }
        
        [ServerIgnore]
        public string CreatedDate
        {
            get
            {
                return UIHelper.GetDateCreatedString(this.CreatedAt);
            }
        }
        
        [ServerIgnore]
        public int LikesCount
        {
            get
            {
                int count = 0;
                if (this.Likes != null)
                {
                    count = this.Likes.Count;
                }
                
                return count;
            }
        }
        
        [ServerIgnore]
        public string LikesCountString
        {
            get
            {
                int count = this.LikesCount;
                if (count == 1)
                {
                    return "1 like";
                }
                else
                {
                    return String.Format("{0} likes", count);
                }
            }
        }
        
        [ServerIgnore]
        public int CommentsCount
        {
            get
            {
                if (!this.commentsCount.HasValue)
                {
                    this.RetrieveCommentsCount();
                    return 0;
                }
                else
                {
                    return this.commentsCount.Value;
                }
            }
            set
            {
                this.commentsCount = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("CommentsCount"));
                this.OnPropertyChanged(new PropertyChangedEventArgs("CommentsCountString"));
                this.OnPropertyChanged(new PropertyChangedEventArgs("LikesAndCommentsCount"));
            }
        }
        
        [ServerIgnore]
        public string CommentsCountString
        {
            get
            {
                var count = this.CommentsCount;
                
                if (count == 1)
                {
                    return "1 comment";
                }
                else
                {
                    return String.Format("{0} comments", count);
                }
            }
        }
        
        [ServerIgnore]
        public string LikesAndCommentsCount
        {
            get
            {
                return this.LikesCountString + ", " + this.CommentsCountString;
            }
        }
        
        [ServerIgnore]
        public Stream PictureStream { get; set; }
        
        private string pictureFileUri;
        
        [ServerIgnore]
        public string PictureFileUri
        {
            get
            {
                if (this.pictureFileUri == null)
                {
                    this.pictureFileUri = (CloudProvider.Current as ICloudProvider).GetFileDownloadUrl(this.pictureFileId);
                }
                
                return this.pictureFileUri;  
            }
        }
        
        #endregion
        
        #region Private Fields and Constants
        
        private string userDisplayName = null;
        private int? commentsCount;
        
        #endregion
        
        private async void RetrieveDisplayName()
        {
            EverliveApp app = CloudProvider.Current.NativeConnection as EverliveApp;
            
            try
            {
                var result = await app.WorkWith().Data<CustomUser>().GetById(this.userId).ExecuteAsync();
                
                if (!String.IsNullOrEmpty(result.DisplayName))
                {
                    this.AuthorName = result.DisplayName;
                }
                else
                {
                    this.AuthorName = result.Email;
                }
            }
            catch (Exception ex)
            {
            }
        }
        
        private async void RetrieveCommentsCount()
        {
            EverliveApp app = CloudProvider.Current.NativeConnection as EverliveApp;
            
            try
            {
                int count = await app.WorkWith().Data<Comment>().GetCount().Where(comment => comment.ActivityId == this.Id).ExecuteAsync();
                
                this.CommentsCount = count;
            }
            catch (Exception ex)
            {
            }
        }
    }
}

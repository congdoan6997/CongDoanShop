﻿using CongDoan.Model.Models;
using CongDoan.Web.Models;

namespace CongDoan.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdatePostCategory(this PostCategory postCategory, PostCategoryViewModel postCategoryViewModel)
        {
            //      public int ID { get; set; }

            //public string Name { get; set; }

            //public string Alias { get; set; }

            //public string Description { get; set; }
            //public int? ParentID { get; set; }
            //public int? DisplayOrder { get; set; }

            //public string Image { get; set; }
            //public bool? HomFlag { get; set; }

            //public virtual IEnumerable<PostViewModel> Posts { get; set; }
            //       public DateTime? CreatedDate { get; set; }

            //[MaxLength(256)]
            //public string CreatedBy { get; set; }

            //public DateTime? UpdatedDate { get; set; }

            //[MaxLength(256)]
            //public string UpdatedBy { get; set; }

            //[MaxLength(256)]
            //public string MetaKeyword { get; set; }

            //[MaxLength(256)]
            //public string MetaDescription { get; set; }

            //public bool Status { get; set; }
            //       public DateTime? CreatedDate { get; set; }

            //[MaxLength(256)]
            //public string CreatedBy { get; set; }

            //public DateTime? UpdatedDate { get; set; }

            //[MaxLength(256)]
            //public string UpdatedBy { get; set; }

            //[MaxLength(256)]
            //public string MetaKeyword { get; set; }

            //[MaxLength(256)]
            //public string MetaDescription { get; set; }

            //public bool Status { get; set; }
            postCategory.ID = postCategoryViewModel.ID;
            postCategory.Name = postCategoryViewModel.Name;
            postCategory.Alias = postCategoryViewModel.Alias;
            postCategory.Description = postCategoryViewModel.Description;
            postCategory.ParentID = postCategoryViewModel.ParentID;
            postCategory.DisplayOrder = postCategoryViewModel.DisplayOrder;
            postCategory.Image = postCategoryViewModel.Image;
            postCategory.HomFlag = postCategoryViewModel.HomFlag;

            postCategory.CreatedBy = postCategoryViewModel.CreatedBy;
            postCategory.UpdatedDate = postCategoryViewModel.UpdatedDate;
            postCategory.UpdatedBy = postCategoryViewModel.UpdatedBy;
            postCategory.MetaKeyword = postCategoryViewModel.MetaKeyword;
            postCategory.MetaDescription = postCategoryViewModel.MetaDescription;
            postCategory.Status = postCategoryViewModel.Status;
        }

        public static void UpdatePost(this Post post, PostViewModel postViewModel)
        {
            //     public int ID { get; set; }

            //public string Name { get; set; }

            //public string Alias { get; set; }

            //public int CategoryID { get; set; }

            //public string Image { get; set; }

            //public string Description { get; set; }
            //public string Content { get; set; }

            //public bool? HomeFlag { get; set; }
            //public bool? HotFlag { get; set; }
            //public int? ViewCount { get; set; }
            post.ID = postViewModel.ID;
            post.Name = postViewModel.Name;
            post.Alias = postViewModel.Alias;
            post.Description = postViewModel.Description;
            post.CategoryID = postViewModel.CategoryID;
            post.HotFlag = postViewModel.HotFlag;
            post.Image = postViewModel.Image;
            post.Content = postViewModel.Content;
            post.ViewCount = postViewModel.ViewCount;
            post.HomeFlag = postViewModel.HomeFlag;

            post.CreatedBy = postViewModel.CreatedBy;
            post.UpdatedDate = postViewModel.UpdatedDate;
            post.UpdatedBy = postViewModel.UpdatedBy;
            post.MetaKeyword = postViewModel.MetaKeyword;
            post.MetaDescription = postViewModel.MetaDescription;
            post.Status = postViewModel.Status;
        }
    }
}
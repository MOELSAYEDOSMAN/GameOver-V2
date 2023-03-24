﻿// <auto-generated />
using System;
using GameOver_V2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameOver_V2.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230322224858_AddClassFrindAndChatAndPostsAndShare")]
    partial class AddClassFrindAndChatAndPostsAndShare
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GameOver_V2.Data.BackGroundImageNews", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NameImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewsIdGameOverNews")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("NewsIdGameOverNews");

                    b.ToTable("BackGroundImageNews");
                });

            modelBuilder.Entity("GameOver_V2.Data.buyGame", b =>
                {
                    b.Property<string>("IdbuyGame")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("gameIdGame")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdbuyGame");

                    b.HasIndex("UserId");

                    b.HasIndex("gameIdGame");

                    b.ToTable("buyGames");
                });

            modelBuilder.Entity("GameOver_V2.Data.Chat", b =>
                {
                    b.Property<string>("IdChat")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SendTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("groubIdGroub")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdChat");

                    b.HasIndex("UserId");

                    b.HasIndex("groubIdGroub");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("GameOver_V2.Data.Chat_User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date_Sent")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReciveId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SendId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ReciveId");

                    b.HasIndex("SendId");

                    b.ToTable("Chat_User");
                });

            modelBuilder.Entity("GameOver_V2.Data.Comments", b =>
                {
                    b.Property<string>("IdComments")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("gameIdGame")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("numberDisLike")
                        .HasColumnType("int");

                    b.Property<int>("numberLike")
                        .HasColumnType("int");

                    b.HasKey("IdComments");

                    b.HasIndex("UserId");

                    b.HasIndex("gameIdGame");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("GameOver_V2.Data.CommentsPost", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SharePId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Whe_Write")
                        .HasColumnType("datetime2");

                    b.Property<string>("WriteId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("nDislike")
                        .HasColumnType("int");

                    b.Property<int>("nlike")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("SharePId");

                    b.HasIndex("WriteId");

                    b.ToTable("CommentsPosts");
                });

            modelBuilder.Entity("GameOver_V2.Data.Frind", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ReciveId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SendId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("acctept")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ReciveId");

                    b.HasIndex("SendId");

                    b.ToTable("Frinds");
                });

            modelBuilder.Entity("GameOver_V2.Data.Game", b =>
                {
                    b.Property<string>("IdGame")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Age")
                        .HasColumnType("bit");

                    b.Property<string>("Cpu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateDownload")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gpu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hard")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Ram")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bigDec")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("disLikeN")
                        .HasColumnType("int");

                    b.Property<int>("downloadNumber")
                        .HasColumnType("int");

                    b.Property<string>("iconSrc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("likeN")
                        .HasColumnType("int");

                    b.Property<string>("lowDec")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdGame");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GameOver_V2.Data.GameOverNews", b =>
                {
                    b.Property<string>("IdGameOverNews")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Dec")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgSrc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("News")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdGameOverNews");

                    b.ToTable("GameOverNews");
                });

            modelBuilder.Entity("GameOver_V2.Data.Groub", b =>
                {
                    b.Property<string>("IdGroub")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Password")
                        .HasColumnType("bit");

                    b.Property<string>("PasswordGroub")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("iconImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("subscriberNumber")
                        .HasColumnType("int");

                    b.HasKey("IdGroub");

                    b.HasIndex("CreatorId");

                    b.ToTable("Groubs");
                });

            modelBuilder.Entity("GameOver_V2.Data.ImageGames", b =>
                {
                    b.Property<string>("IdImageGames")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ImgSrc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gameIdGame")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdImageGames");

                    b.HasIndex("gameIdGame");

                    b.ToTable("ImageGames");
                });

            modelBuilder.Entity("GameOver_V2.Data.PostsUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Comments_")
                        .HasColumnType("int");

                    b.Property<string>("DecPost")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgSrc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Share_")
                        .HasColumnType("int");

                    b.Property<DateTime>("WhUpload")
                        .HasColumnType("datetime2");

                    b.Property<int>("nDisLike")
                        .HasColumnType("int");

                    b.Property<int>("nLike")
                        .HasColumnType("int");

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.ToTable("PostsUsers");
                });

            modelBuilder.Entity("GameOver_V2.Data.SharePost", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Comments_")
                        .HasColumnType("int");

                    b.Property<string>("PostUId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Share_")
                        .HasColumnType("int");

                    b.Property<string>("UsShareId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("W_share")
                        .HasColumnType("datetime2");

                    b.Property<int>("nDisLike")
                        .HasColumnType("int");

                    b.Property<int>("nLike")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostUId");

                    b.HasIndex("UsShareId");

                    b.ToTable("SharePosts");
                });

            modelBuilder.Entity("GameOver_V2.Data.SubscriberGroub", b =>
                {
                    b.Property<string>("IdSubscriberGroub")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("groubIdGroub")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdSubscriberGroub");

                    b.HasIndex("UserId");

                    b.HasIndex("groubIdGroub");

                    b.ToTable("SubscriberGroubs");
                });

            modelBuilder.Entity("GameOver_V2.Data.UserMoreInfromation", b =>
                {
                    b.Property<string>("IdUserMoreInfromation")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageSrc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdUserMoreInfromation");

                    b.HasIndex("UserId");

                    b.ToTable("userMData");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("GameOver_V2.Data.BackGroundImageNews", b =>
                {
                    b.HasOne("GameOver_V2.Data.GameOverNews", "News")
                        .WithMany("ImageNews")
                        .HasForeignKey("NewsIdGameOverNews")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("News");
                });

            modelBuilder.Entity("GameOver_V2.Data.buyGame", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("GameOver_V2.Data.Game", "game")
                        .WithMany()
                        .HasForeignKey("gameIdGame")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("game");
                });

            modelBuilder.Entity("GameOver_V2.Data.Chat", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("GameOver_V2.Data.Groub", "groub")
                        .WithMany()
                        .HasForeignKey("groubIdGroub")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("groub");
                });

            modelBuilder.Entity("GameOver_V2.Data.Chat_User", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Recive")
                        .WithMany()
                        .HasForeignKey("ReciveId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Send")
                        .WithMany()
                        .HasForeignKey("SendId");

                    b.Navigation("Recive");

                    b.Navigation("Send");
                });

            modelBuilder.Entity("GameOver_V2.Data.Comments", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("GameOver_V2.Data.Game", "game")
                        .WithMany("Comments")
                        .HasForeignKey("gameIdGame")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("game");
                });

            modelBuilder.Entity("GameOver_V2.Data.CommentsPost", b =>
                {
                    b.HasOne("GameOver_V2.Data.PostsUser", "Post")
                        .WithMany("comments")
                        .HasForeignKey("PostId");

                    b.HasOne("GameOver_V2.Data.SharePost", "ShareP")
                        .WithMany("commentsPosts")
                        .HasForeignKey("SharePId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Write")
                        .WithMany()
                        .HasForeignKey("WriteId");

                    b.Navigation("Post");

                    b.Navigation("ShareP");

                    b.Navigation("Write");
                });

            modelBuilder.Entity("GameOver_V2.Data.Frind", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Recive")
                        .WithMany()
                        .HasForeignKey("ReciveId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Send")
                        .WithMany()
                        .HasForeignKey("SendId");

                    b.Navigation("Recive");

                    b.Navigation("Send");
                });

            modelBuilder.Entity("GameOver_V2.Data.Groub", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("GameOver_V2.Data.ImageGames", b =>
                {
                    b.HasOne("GameOver_V2.Data.Game", "game")
                        .WithMany("Images")
                        .HasForeignKey("gameIdGame");

                    b.Navigation("game");
                });

            modelBuilder.Entity("GameOver_V2.Data.PostsUser", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "user")
                        .WithMany()
                        .HasForeignKey("userId");

                    b.Navigation("user");
                });

            modelBuilder.Entity("GameOver_V2.Data.SharePost", b =>
                {
                    b.HasOne("GameOver_V2.Data.PostsUser", "PostU")
                        .WithMany()
                        .HasForeignKey("PostUId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "UsShare")
                        .WithMany()
                        .HasForeignKey("UsShareId");

                    b.Navigation("PostU");

                    b.Navigation("UsShare");
                });

            modelBuilder.Entity("GameOver_V2.Data.SubscriberGroub", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("GameOver_V2.Data.Groub", "groub")
                        .WithMany("subscribers")
                        .HasForeignKey("groubIdGroub");

                    b.Navigation("User");

                    b.Navigation("groub");
                });

            modelBuilder.Entity("GameOver_V2.Data.UserMoreInfromation", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameOver_V2.Data.Game", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Images");
                });

            modelBuilder.Entity("GameOver_V2.Data.GameOverNews", b =>
                {
                    b.Navigation("ImageNews");
                });

            modelBuilder.Entity("GameOver_V2.Data.Groub", b =>
                {
                    b.Navigation("subscribers");
                });

            modelBuilder.Entity("GameOver_V2.Data.PostsUser", b =>
                {
                    b.Navigation("comments");
                });

            modelBuilder.Entity("GameOver_V2.Data.SharePost", b =>
                {
                    b.Navigation("commentsPosts");
                });
#pragma warning restore 612, 618
        }
    }
}

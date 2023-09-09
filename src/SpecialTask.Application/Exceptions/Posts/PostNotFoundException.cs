namespace SpecialTask.Application.Exceptions.Posts
{
    public class PostNotFoundException : NotFoundException
    {
        public PostNotFoundException()
        {
            this.TitleMessage = "Post not found !";
        }
    }
}

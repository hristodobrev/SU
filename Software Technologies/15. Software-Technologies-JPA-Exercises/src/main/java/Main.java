import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.persistence.criteria.CriteriaBuilder;
import javax.persistence.criteria.CriteriaQuery;
import javax.persistence.criteria.Root;
import java.time.LocalDateTime;
import java.util.List;

public class Main {
    public static void main(String[] args) {
        EntityManagerFactory emf = Persistence.createEntityManagerFactory("JPAExercises");
        EntityManager em = emf.createEntityManager();

        CriteriaBuilder cb = em.getCriteriaBuilder();

        try {
//            listAllPosts(em, cb);
//            listAllUsers(em, cb);
//            orderUsersByUsername(em, cb);
//            orderUsersByTwoParameters(em, cb);
//            getAuthors(em, cb);
//            getAuthorsWithTitles(em, cb);
//            getSpecificAuthor(em, cb);
//            createNewPost(em);
//            editPost(em);
            deletePost(em);
        } finally {
            em.close();
            emf.close();
        }
    }

    private static void deletePost(EntityManager entityManager) {
        Post post = entityManager.find(Post.class, 32);

        entityManager.getTransaction().begin();

        post.getComments().clear();
        post.getTags().clear();
        entityManager.remove(post);

        entityManager.getTransaction().commit();
    }

    private static void editPost(EntityManager entityManager) {
        Post post = entityManager.find(Post.class, 32);

        post.setContent("Random changed content.");

        entityManager.getTransaction().begin();
        entityManager.persist(post);
        entityManager.getTransaction().commit();
    }

    private static void createNewPost(EntityManager entityManager) {
        User user = entityManager.find(User.class, 2);

        LocalDateTime date = LocalDateTime.now();

        Post post = new Post();
        post.setTitle("New Post");
        post.setContent("<p>Post content.</p>");
        post.setDate(date);
        post.setAuthor(user);

        entityManager.getTransaction().begin();
        entityManager.persist(post);
        entityManager.getTransaction().commit();
    }

    private static void getSpecificAuthor(EntityManager entityManager, CriteriaBuilder criteriaBuilder) {
        CriteriaQuery<User> query = criteriaBuilder.createQuery(User.class);
        Root<User> userRoot = query.from(User.class);

        query.where(criteriaBuilder.equal(userRoot.join("posts").get("id"), 4))
                .select(userRoot);

        List<User> users = entityManager.createQuery(query).getResultList();

        for (User user : users) {
            System.out.println("Username: " + user.getUsername());
            System.out.println("Name: " + user.getFullname());
        }
    }

    private static void getAuthorsWithTitles(EntityManager entityManager, CriteriaBuilder criteriaBuilder) {
        CriteriaQuery<Post> query = criteriaBuilder.createQuery(Post.class);
        Root<Post> postRoot = query.from(Post.class);

        query.select(postRoot);

        List<Post> posts = entityManager.createQuery(query).getResultList();

        for (Post post : posts) {
            System.out.println("Author: " + post.getAuthor().getUsername());
            System.out.println("Title: " + post.getTitle());
        }
    }

    private static void getAuthors(EntityManager entityManager, CriteriaBuilder criteriaBuilder) {
        CriteriaQuery<User> query = criteriaBuilder.createQuery(User.class);
        Root<User> userRoot = query.from(User.class);

        query.where(
                criteriaBuilder.gt(
                        criteriaBuilder.size(
                                userRoot.get("posts")), 0))
                .select(userRoot);

        List<User> users = entityManager.createQuery(query).getResultList();

        for (User user : users) {
            System.out.println("Username: " + user.getUsername());
            System.out.println("Name: " + user.getFullname());
            System.out.println("Count: " + user.getPosts().size());
        }
    }

    private static void orderUsersByTwoParameters(EntityManager entityManager, CriteriaBuilder criteriaBuilder) {
        CriteriaQuery<User> query = criteriaBuilder.createQuery(User.class);
        Root<User> userRoot = query.from(User.class);

        query.select(userRoot);
        query.orderBy(criteriaBuilder.desc(userRoot.get("username")), criteriaBuilder.desc(userRoot.get("fullname")));

        List<User> users = entityManager.createQuery(query).getResultList();

        for (User user : users) {
            System.out.println("Username: " + user.getUsername());
            System.out.println("Name: " + user.getFullname());
        }
    }

    private static void orderUsersByUsername(EntityManager entityManager, CriteriaBuilder criteriaBuilder) {
        CriteriaQuery<User> query = criteriaBuilder.createQuery(User.class);
        Root<User> userRoot = query.from(User.class);

        query.select(userRoot);
        query.orderBy(criteriaBuilder.asc(userRoot.get("username")));

        List<User> users = entityManager.createQuery(query).getResultList();

        for (User user : users) {
            System.out.println("Username: " + user.getUsername());
            System.out.println("Name: " + user.getFullname());
        }
    }

    private static void listAllUsers(EntityManager entityManager, CriteriaBuilder criteriaBuilder) {
        CriteriaQuery<User> query = criteriaBuilder.createQuery(User.class);
        Root<User> userRoot = query.from(User.class);

        query.select(userRoot);

        List<User> users = entityManager.createQuery(query).getResultList();

        for (User user : users) {
            System.out.println("ID: " + user.getId());
            System.out.println("Name: " + user.getFullname());
            System.out.println("Username: " + user.getUsername());
        }
    }

    private static void listAllPosts(EntityManager entityManager, CriteriaBuilder criteriaBuilder) {
        CriteriaQuery<Post> query = criteriaBuilder.createQuery(Post.class);
        Root<Post> postRoot = query.from(Post.class);

        query.select(postRoot);

        List<Post> posts = entityManager.createQuery(query).getResultList();

        for (Post post : posts) {
            System.out.println("Title: " + post.getTitle());
            System.out.println("Author ID: " + post.getAuthor().getId());
        }
    }
}

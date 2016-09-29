import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.persistence.Query;
import java.time.LocalDateTime;
import java.util.Date;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;

public class Main {
    public static void main(String[] args) {
        Logger.getLogger("org.hibernate").setLevel(Level.SEVERE);

        EntityManagerFactory emf = Persistence
                .createEntityManagerFactory("blog-db");
        EntityManager em = emf.createEntityManager();

//        populateDatabase(emf, em);
//        editUser(emf, em);
//        deleteUser(emf, em);
        executeNativeQuery(emf, em);
    }

    private static void executeNativeQuery(EntityManagerFactory emf, EntityManager em) {
        try {
            em.getTransaction().begin();

            LocalDateTime startDate =
                    LocalDateTime.parse("2016-05-19T12:00:00");
            LocalDateTime endDate = LocalDateTime.now();

            Query postsQuery = em.createNativeQuery(
                    "SELECT id, title, date, body, author_id FROM posts " +
                            "WHERE CONVERT(date, Date) " +
                            "BETWEEN :startDate AND :endDate", Post.class)
                    .setParameter("startDate", startDate)
                    .setParameter("endDate", endDate);

            List<Post> posts = postsQuery.getResultList();
            for (Post post : posts)
                System.out.println(post);

            em.getTransaction().commit();
        } finally {
            em.close();
            emf.close();
        }
    }

    private static void deleteUser(EntityManagerFactory emf, EntityManager em) {
        try {
            em.getTransaction().begin();

            User user = em.find(User.class, 1L);
            for (Post post : user.getPosts()) {
                em.remove(post);
            }
            em.remove(user);

            System.out.println("Deleted existing user #" + user.getId());

            em.getTransaction().commit();
        } finally {
            em.close();
            emf.close();
        }
    }

    private static void editUser(EntityManagerFactory emf, EntityManager em) {
        try {
            em.getTransaction().begin();

            User user = em.find(User.class, 1L);
            user.setPasswordHash("" + new Date().getTime());

            em.persist(user);

            System.out.println("Edited existing user #" + user.getId());

            em.getTransaction().commit();
        } finally {
            em.close();
            emf.close();
        }
    }

    public static void populateDatabase(EntityManagerFactory emf, EntityManager em) {
        try {
            em.getTransaction().begin();

            User user = new User();
            user.setUsername("pesho");
            em.persist(user);
            System.out.println("Created new user #" + user.getId());

            for (int i = 0; i < 10; i++) {
                Post post = new Post();
                post.setAuthor(user);
                post.setTitle("Post Title #" + LocalDateTime.now());
                post.setBody("<p>Body #" + LocalDateTime.now() + "</p>");
                em.persist(post);
                System.out.println("Created new post #" + post.getId());
            }

            em.getTransaction().commit();
        } finally {
            em.close();
            emf.close();
        }
    }
}

class RegisterView
{
    constructor() {
        this.html = `
        <section id="register-view" class="register-view">
        <h2>Register</h2>
        <br>
          <form id="register-form" method="POST" action="https://baas.kinvey.com/user/kid_rkax2fPfe">
            <div class="form-group">
              <label for="username">Username</label>
              <input type="text" class="form-control" name="username" id="username" aria-describedby="usernameHelp" placeholder="Username">
            </div>
            <div class="form-group">
              <label for="password">Password</label>
              <input type="password" class="form-control" name="password" id="password" placeholder="Password" />
            </div>
            <input type="submit" class="btn btn-primary" value="Register" />
          </form>
        </section>
        `;
        return this;
    }
}

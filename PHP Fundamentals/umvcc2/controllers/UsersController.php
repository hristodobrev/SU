<?php

class UsersController extends BaseController
{
    public function login()
    {
        if ($this->isPost) {
            $username = $_POST['username'];
            $password = $_POST['password'];

            $userId = $this->model->login($username, $password);
            if ($userId) {
                $_SESSION['username'] = $username;
                $_SESSION['user_id'] = $userId;
                var_dump($_SESSION);
                $this->addSuccessMessage('Successfully logged in.');
                $this->redirect('');
            } else {
                $this->addErrorMessage("Invalid username or password.");
            }
        }
    }

    public function register()
    {
        if($this->isPost) {
            $username = $_POST['username'];
            if (strlen($username) < 3 || strlen($username) > 50) {
                $this->setValidationError('username', 'Username must consist of 3-50 symbols.');
            }

            $password = $_POST['password'];
            if (strlen($password) < 6 || strlen($password) > 50) {
                $this->setValidationError('password', 'Password must be at least 6 symbols long.');
            }

            $confirmPassword = $_POST['password-confirm'];
            if ($confirmPassword != $password) {
                $this->setValidationError('password-confirm', 'The passwords must be the same.');
            }

            $fullName = $_POST['full-name'];
            if (strlen($fullName) > 80) {
                $this->setValidationError('full-name', 'Full name can have maximum 80 characters.');
            }

            if ($this->formValid()) {
                try {
                    $userId = $this->model->register($username, $password, $fullName);
                    if ($userId) {
                        $_SESSION['username'] = $username;
                        $_SESSION['user_id'] = $userId;
                        var_dump($_SESSION);

                        $this->addSuccessMessage('You have registered successfully.');
                        $this->redirect('');
                    } else {
                        $this->addErrorMessage("Something failed very hard.");
                    }
                } catch (Error $error) {
                    $this->addErrorMessage($error->getMessage());
                }
            }
        }
    }

    public function logout() {
        session_unset();
        $this->addSuccessMessage("Logout successful.");
        $this->redirect('');
    }
}

?>
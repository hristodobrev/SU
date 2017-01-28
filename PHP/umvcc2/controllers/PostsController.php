<?php

class PostsController extends BaseController
{
    function onInit()
    {
        $this->authorize();
    }

    public function index()
    {
        $this->posts = $this->model->getAll();
    }

    public function create() {
        if ($this->isPost) {
            $img = $_POST['image'];
            $title = $_POST['title'];
            if (strlen($title) < 10) {
                $this->setValidationError('title', 'Title must have at least 10 characters.');
            }

            $content = $_POST['content'];
            if (strlen($content) < 1) {
                $this->setValidationError('content', 'Content must not be empty.');
            }

            $authorId = $_SESSION['user_id'];
            var_dump($authorId);
            if ($this->formValid()) {
                if ($this->model->create($img, $title, $content, $authorId)) {
                    $this->addSuccessMessage('Successfully created post.');
                } else {
                    $this->addErrorMessage('Failed to create post.');
                }

                $this->redirect('');
            }
        }
    }
}

?>
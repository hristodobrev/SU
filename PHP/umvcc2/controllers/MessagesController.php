<?php

class MessagesController extends BaseController
{
    public function index() {
        if ($this->isPost) {
            $friendId = $_POST['friend-id'];
            $_SESSION['friend_id'] = $friendId;
            $this->redirect('messages', 'chat');
        }
    }

    public function chat() {
        if (!isset($_SESSION['friend_id'])) {
            $this->addErrorMessage('You have to select friend id first.');
            $this->redirect('messages');
        }

        $this->messages = $this->model->getMessages($_SESSION['user_id'], $_SESSION['friend_id']);

        if ($this->isPost) {
            $message = $_POST['message'];
            $friendId = $_SESSION['friend_id'];
            $userId = $_SESSION['user_id'];
            if (!$this->model->sendMessage($userId, $friendId, $message)) {
                $this->addErrorMessage('Message cound not be send.');
            } else {
                $this->redirect('messages', 'chat');
            }
        }
    }
}

?>
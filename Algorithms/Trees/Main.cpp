// CPPConsoleApplication1.cpp : Defines the entry point for the console application.
//

#include <stdio.h>
#include <stdarg.h>

struct Node {
	int data;
	struct Node *left;
	struct Node *right;
};

Node * insert(Node *root, int data);
Node * create(int count, ...);
void inOrder(Node *root);
void release(Node *root);

Node * create(int count, ...) {
	va_list ap;
	Node *root = NULL;
	va_start(ap, count);
	for (int i = 0; i < count; i++) {
		root = insert(root, va_arg(ap, int));
	}
	va_end(ap);
	return root;
}
Node * insert(Node *root, int data) {
	Node *newNode = new Node();
	newNode->data = data;
	newNode->left = newNode->right = NULL;
	if (root) {
		if (root->data > data) {
			root->left = insert(root->left, data);
		}
		else {
			root->right = insert(root->right, data);
		}
		return root;
	}
	else {
		return newNode;
	}
}
void inOrderInternal(Node *node){
	if (!node) return;
	inOrderInternal(node->left);
	printf("%d ", node->data);
	inOrderInternal(node->right);
}
void inOrder(Node *root) {
	inOrderInternal(root);
	printf("\n");
}
void release(Node *root) {
	if (root) {
		release(root->left);
		release(root->right);
		delete root;
	}
}

bool checkInOrder(Node *root, int *value) {
	if (!root) return true;
	bool isInOrder = true;
	if (root->left) {
		if (!checkInOrder(root->left, value)){
			return false;
		}
	}
	if (*value >= root->data) return false;
	*value = root->data;
	if (root->right) {
		if (!checkInOrder(root->right, value)) {
			return false;
		}
	}

	return true;
}
bool checkBST(Node *root) {
	if (!root) return true;
	int value = -1;
	return checkInOrder(root, &value);
}
void testCheckBST(){
	Node *root;
	root = create(7, 4, 2, 6, 1, 3, 5, 7);
	printf("IsBST (yes): %d\n", checkBST(root));
	release(root);

	root = create(15,
		8,
		4, 12,
		2, 6, 10, 14,
		1, 3, 5, 7, 9, 11, 13, 15);
	printf("IsBST (yes): %d\n", checkBST(root));
	release(root);

	root = create(7, 4, 2, 6, 1, 3, 5, 7);
	root->left->right->data = 2;
	printf("IsBST (no): %d\n", checkBST(root));
	release(root);

	root = create(1, 3);
	root->left = create(1, 2);
	root->left->left = create(1, 1);
	root->left->right = create(1, 4);
	root->right = create(1, 6);
	root->right->left = create(1, 5);
	root->right->right = create(1, 7);
	printf("IsBST: %d\n", checkBST(root));
	release(root);

	root = create(1, 4);
	root->left = create(1, 2);
	root->left->left = create(1, 1);
	root->left->right = create(1, 2);
	root->right = create(1, 6);
	root->right->left = create(1, 5);
	root->right->right = create(1, 7);
	printf("IsBST (no): %d\n", checkBST(root));
	release(root);

	root = create(1, 4);
	root->right = create(1, 3);
	printf("IsBST (no): %d\n", checkBST(root));
	release(root);

	root = create(31,
		16,
		8, 24,
		4, 12, 20, 28,
		2, 6, 10, 14, 18, 22, 26, 30,
		1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31);
	root->data = 17;
	root->right->left->left->left->data = 16;
	inOrder(root);
	printf("IsBST (no): %d\n", checkBST(root));
	release(root);
}
int main()
{
	testCheckBST();

	return 0;
}
